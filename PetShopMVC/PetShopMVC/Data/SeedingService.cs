using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetShopMVC.Models;
using PetShopMVC.Models.Enums;

namespace PetShopMVC.Data
{
    public class SeedingService
    {
        private PetShopMVCContext _context;

        public SeedingService(PetShopMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
             if (_context.Servico.Any() ||
                 _context.Cliente.Any() ||
                 _context.Agendamento.Any()||
                 _context.Customizar.Any()) 
                
                
            {
               return;
            }


            Servico s1 = new Servico(1, "Banho" , 20);
            Servico s2 = new Servico(2, "Tosa", 15);
            Servico s3 = new Servico(3, "Corte de Unhas", 5);
            Servico s4 = new Servico(4, "Limpeza de Ouvido", 10);

            Cliente c1 = new Cliente(1, "Marcelo Santos", "marcelo.santos@gmail.com", "967585821", "Rua Maria das Graças , 12 - Santo André - SP", s1, "Gato");
            Cliente c2 = new Cliente(2, "Josefina de Souza", "josefina@gmail.com", "989578477", "Rua Alto da Bela Vista , 20 - Mauá - SP", s2, "Cachorro");
            Cliente c3 = new Cliente(3, "Antonio Carlos Pereira", "antoniop@gmail.com", "964846895", "Rua Forte dos Reis Magos, 25 - Guarulhos - SP", s3, "Gato");
            Cliente c4 = new Cliente(4, "Experidião Joaquim Marques", "ejoaquimmarques@gmail.com", "968978452", "Rua Imperatriz , 58 - Lapa - SP", s4, "Cachorro");


            Agendamento ag1 = new Agendamento(1, new DateTime(2022, 10, 15), 20.0, AgendamentoStatus.Pendente, c1);
            Agendamento ag2 = new Agendamento(2, new DateTime(2022, 10, 15), 15.0, AgendamentoStatus.Pendente, c1);
            Agendamento ag3 = new Agendamento(3, new DateTime(2022, 10, 15), 5.0, AgendamentoStatus.Pendente, c2);
            Agendamento ag4 = new Agendamento(4, new DateTime(2022, 10, 15), 10.0, AgendamentoStatus.Pendente, c2);
            Agendamento ag5 = new Agendamento(5, new DateTime(2022, 10,15), 20.0, AgendamentoStatus.Pendente, c3);
            Agendamento ag6 = new Agendamento(6, new DateTime(2022, 10, 12), 20.0, AgendamentoStatus.Realizado, c1);
            Agendamento ag7 = new Agendamento(7, new DateTime(2022, 10, 12), 20.0, AgendamentoStatus.Realizado, c2);
            Agendamento ag8 = new Agendamento(8, new DateTime(2022, 10, 12), 20.0, AgendamentoStatus.Realizado, c2);
            Agendamento ag9 = new Agendamento(9, new DateTime(2022, 10, 12), 20.0, AgendamentoStatus.Realizado, c3);
            Agendamento ag10 = new Agendamento(10, new DateTime(2022, 10, 12), 20.0, AgendamentoStatus.Realizado, c4);
            Agendamento ag11 = new Agendamento(11, new DateTime(2022, 10, 17), 20.0, AgendamentoStatus.Pendente, c1);
            Agendamento ag12 = new Agendamento(12, new DateTime(2022, 10, 17), 20.0, AgendamentoStatus.Pendente, c1);

            Customizar cs1 = new Customizar(1, "Marcelo Santos", "marcelo.santos@gmail.com", "967585821", "Rua Maria das Graças , 12 - Santo André - SP", s1);
            Customizar cs2 = new Customizar(2, "Josefina de Souza", "josefina@gmail.com", "989578477", "Rua Alto da Bela Vista , 20 - Mauá - SP", s2);
            Customizar cs3 = new Customizar(3, "Antonio Carlos Pereira", "antoniop@gmail.com", "964846895", "Rua Forte dos Reis Magos, 25 - Guarulhos - SP", s3);
            Customizar cs4 = new Customizar(4, "Experidião Joaquim Marques", "ejoaquimmarques@gmail.com", "968978452", "Rua Imperatriz , 58 - Lapa - SP", s4);

            _context.Servico.AddRange(s1, s2, s3, s4);

            _context.Cliente.AddRange(c1, c2, c3, c4);

            _context.Agendamento.AddRange(
                ag1, ag2, ag3, ag4, ag5, ag6, ag7, ag8,
                ag9, ag10, ag11, ag12);

            _context.Customizar.AddRange(cs1, cs2, cs3, cs4);
                

            _context.SaveChanges();
        }
    }
}
