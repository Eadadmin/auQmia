using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopMVC.Models
{
    public class Cliente
    {
        internal static int id;
        private int _id;

        public int Id { get => _id; set => _id = value; }

        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do nome deve ser entre 3 e 60 caracteres")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Entre com um email válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Endereco { get; set; }

        public Servico Servico { get; set; }

        public string Animal { get; set; }

        [Required]
        public int ServicoId { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

 

        public Cliente()
        {

        }

        public Cliente(int Id, string name, string email, string telefone, string endereco, Servico servico, string animal)
        {
            Id = id;
            Name = name;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            Servico = servico;
            Animal = animal;

        }


        public void AddAgendamento(Agendamento ag)
        {
            Agendamentos.Add(ag);
        }


        public void RemoveAgendamento(Agendamento ag)
        {
            Agendamentos.Remove(ag);
        }


        public double ValorAgendamentos(DateTime initial, DateTime final) //
        {
            return Agendamentos.Where(ag => ag.Date >= initial && ag.Date <= final).Sum(ag => ag.Valor);
        }

    }
}
