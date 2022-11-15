using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopMVC.Models
{
    public class ServicoOrdem : Servico
    {
       
        public string Animal { get; set; }
    }
}
