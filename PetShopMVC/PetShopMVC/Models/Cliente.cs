﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopMVC.Models
{
    public class Cliente
    {
        internal static int id;
        private int _id;

        public int Id { get => _id; set => _id = value; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public Servico Servico { get; set; }
        public int ServicoId { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
 

        public Cliente()
        {

        }

        public Cliente(int Id, string name, string email, string telefone, string endereco, Servico servico)
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
