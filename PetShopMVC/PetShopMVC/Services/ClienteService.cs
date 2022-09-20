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

        public List<Cliente> FindAll()
        {
            return _context.Cliente.ToList();
        }
        
        public void Insert(Cliente obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Cliente FindById(int id)
        {
            return _context.Cliente.Include(obj => obj.Servico).FirstOrDefault(obj => obj.Id == id);

        }
        public void Remove(int id)
        {
            var obj = _context.Cliente.Find(id);
            _context.Cliente.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Cliente obj)
        {
            if (!_context.Cliente.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException(" Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
    
}
