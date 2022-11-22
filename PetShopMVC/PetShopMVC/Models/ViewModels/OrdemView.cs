using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopMVC.Models.ViewModels
{
    public class OrdemView
    {
        //public Cliente Cliente { get; set; }
        //public Servico Servico { get; set; }
        public Customizar Customizar { get; set; }
        public ServicoOrdem Servico { get; set; }

        public List<ServicoOrdem> ServicoOrdem { get; set; }



    }
}
