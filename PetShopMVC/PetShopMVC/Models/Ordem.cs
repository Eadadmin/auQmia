using PetShopMVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopMVC.Models
{
    public class Ordem
    {
        [Key]

        public int OrdemId { get; set; }

        public DateTime OrdemData { get; set; }

        public int ClienteId { get; set; }






        public virtual Customizar Customizar { get; set; }

        public virtual ICollection<OrdemDetalhe> OrdemDetalhe { get; set; }


    }
}
