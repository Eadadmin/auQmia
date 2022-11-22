using PetShopMVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopMVC.Models
{
    public class OrdemDetalhe
    {

        [Key]

        public int OrdemDetalheId { get; set; }

        public int OrdemId { get; set; }

        public int ServicoId { get; set; }

        public AgendamentoStatus OrdemStatus { get; set; }

        public string ServicoName { get; set; }

        public decimal Preco { get; set; }


        public virtual Ordem Ordem { get; set; }
        public virtual Customizar Customizar { get; set; }
        public virtual Servico Servico { get; set; }




    }
}
