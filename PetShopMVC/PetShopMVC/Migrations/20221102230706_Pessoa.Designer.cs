﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetShopMVC.Models;

namespace PetShopMVC.Migrations
{
    [DbContext(typeof(PetShopMVCContext))]
    [Migration("20221102230706_Pessoa")]
    partial class Pessoa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Animal");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Endereco")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<int>("ServicoId");

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ServicoId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("PetShopMVC.Models.Customizar", b =>
                {
                    b.Property<int>("CustomizarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Endereco");

                    b.Property<string>("Name");

                    b.Property<int>("ServicoId");

                    b.Property<string>("Telefone");

                    b.HasKey("CustomizarId");

                    b.HasIndex("ServicoId");

                    b.ToTable("Customizar");
                });

            modelBuilder.Entity("PetShopMVC.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("PetShopMVC.Models.Agendamento", b =>
                {
                    b.HasOne("PetShopMVC.Models.Cliente", "Cliente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("PetShopMVC.Models.Cliente", b =>
                {
                    b.HasOne("PetShopMVC.Models.Servico", "Servico")
                        .WithMany("Clientes")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetShopMVC.Models.Customizar", b =>
                {
                    b.HasOne("PetShopMVC.Models.Servico", "Servico")
                        .WithMany("Customizacao")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
