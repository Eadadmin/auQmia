using PetShopMVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PetShopMVC.Models
{
    public class Agendamento
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]

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
