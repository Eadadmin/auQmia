using PetShopMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PetShopMVC.Models
{
    public class Customizar
    {
       public int CustomizarId { get; set; }

 
       public string Name { get; set; }

       public string Email { get; set; }

  
       public string Telefone { get; set; }

   
        public string Endereco { get; set; }

        public virtual Servico Servico { get; set; }

        
        public int ServicoId { get; set; }

        public ICollection<Ordem> Ordem { get; set; }


        public Customizar()
        {

        }

        public Customizar(int customizarid, string name, string email, string telefone, string endereco, Servico servico)
        {
            CustomizarId = customizarid;
            Name = name;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            Servico = servico;
           
          

        }

    }
}
