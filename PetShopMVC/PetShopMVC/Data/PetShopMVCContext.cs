using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetShopMVC.Models;


namespace PetShopMVC.Models
{
    public class PetShopMVCContext : DbContext
    {
        public PetShopMVCContext()
        {
        }

        public PetShopMVCContext(DbContextOptions<PetShopMVCContext> options)
            : base(options)
        {
        }
        

        public DbSet<Servico> Servico { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Customizar> Customizar { get; set; }
        

    }




}
