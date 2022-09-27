using PetShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetShopMVC.Services.Exceptions;

namespace PetShopMVC.Services
{
    public class ClienteService
    {
        private readonly PetShopMVCContext _context;

        public ClienteService(PetShopMVCContext context)
        {
            _context = context;           
        }

        public async Task<List<Cliente>> FindAllAsync()
        {
            return await _context.Cliente.ToListAsync();
        }
        
        public async Task InsertAsync(Cliente obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> FindByIdAsync(int id)
        {
            return await _context.Cliente.Include(obj => obj.Servico).FirstOrDefaultAsync(obj => obj.Id == id);

        }
        public async Task RemoveAsync(int id)
        {
            try
            {

                var obj = await _context.Cliente.FindAsync(id);
                _context.Cliente.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Cliente obj)
        {
            bool hasAny = await _context.Cliente.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException(" Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        internal Task UpdateAsynv(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
    
}
