using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopMVC.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Telefone { get; set; }
        public string Endereco { get; set; }
        public Servico Servico { get; set; }
        public ICollection<Agendamento> Agendamento { get; set; } = new List<Agendamento>();


        public Cliente()
        {

        }

        public Cliente(int id, string name, string email, double telefone, string endereco, Servico servico)
        {
            Id = id;
            Name = name;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            Servico = servico;
        }


        public void AddAgendamento(Agendamento ag)
        {
            Agendamento.Add(ag);
        }


        public void RemoveAgendamento(Agendamento ag)
        {
            Agendamento.Remove(ag);
        }

        

    }
}
