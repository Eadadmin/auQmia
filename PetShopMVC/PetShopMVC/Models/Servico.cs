﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PetShopMVC.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();


        public Servico ()

        {
        }

        public Servico(int id, string name)
        {
            Id = id;
            Name = name;
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
