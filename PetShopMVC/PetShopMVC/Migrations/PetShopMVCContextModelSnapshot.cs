﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetShopMVC.Models;

namespace PetShopMVC.Migrations
{
    [DbContext(typeof(PetShopMVCContext))]
    partial class PetShopMVCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PetShopMVC.Models.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClienteId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Status");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("PetShopMVC.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Endereco");

                    b.Property<string>("Name");

                    b.Property<int?>("ServicoID");

                    b.Property<double>("Telefone");

                    b.HasKey("Id");

                    b.HasIndex("ServicoID");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("PetShopMVC.Models.Servico", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("PetShopMVC.Models.Agendamento", b =>
                {
                    b.HasOne("PetShopMVC.Models.Cliente", "Cliente")
                        .WithMany("Agendamento")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("PetShopMVC.Models.Cliente", b =>
                {
                    b.HasOne("PetShopMVC.Models.Servico", "Servico")
                        .WithMany("Clientes")
                        .HasForeignKey("ServicoID");
                });
#pragma warning restore 612, 618
        }
    }
}
