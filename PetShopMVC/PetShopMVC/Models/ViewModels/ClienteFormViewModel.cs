using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopMVC.Models.ViewModels
{
    public class ClienteFormViewModel
    {
        public Cliente Cliente { get; set; }
        public ICollection<Servico> Servicos { get; set; }

    }
}
