using PetShopMVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopMVC.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Valor{ get; set; }
        public AgendamentoStatus Status { get; set; }
        public Cliente Cliente { get; set; } //

        public Agendamento()
        {
        }

        public Agendamento(int id, DateTime date, double valor, AgendamentoStatus status, Cliente cliente)
        {
            Id = id;
            Date = date;
            Valor = valor;
            Status = status;
            Cliente = cliente;
        }

        
    }
}
