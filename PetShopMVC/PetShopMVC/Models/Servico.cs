using PetShopMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PetShopMVC.Models
{
    public class Servico
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Preco { get; set; }

        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
        //public ICollection<Customizar> Customizacao { get; set; }
        public ICollection<OrdemDetalhe> OrdemDetalhe { get; set; }
        
     


        public Servico ()

        {
        }

        public Servico(int id, string name, decimal preco)
        {
            Id = id;
            Name = name;
            Preco = preco;
        }

        public void AddCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public double ValorAgendamentos(DateTime initial, DateTime final) //
        {
            return Clientes.Sum(cliente => cliente.ValorAgendamentos(initial, final));
        }


    }
}
