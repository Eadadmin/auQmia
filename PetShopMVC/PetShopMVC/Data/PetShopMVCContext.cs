using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PetShopMVC.Models
{
    public class PetShopMVCContext : DbContext
    {
        public PetShopMVCContext (DbContextOptions<PetShopMVCContext> options)
            : base(options)
        {
        }

        public DbSet<PetShopMVC.Models.Servico> Servico { get; set; }
    }
}
