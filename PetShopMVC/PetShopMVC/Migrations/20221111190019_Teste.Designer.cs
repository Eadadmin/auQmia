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
    [Migration("20221111190019_Teste")]
    partial class Teste
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

            modelBuilder.Entity("PetShopMVC.Models.Ordem", b =>
                {
                    b.Property<int>("OrdemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<int?>("CustomizarId");

                    b.Property<DateTime>("OrdemData");

                    b.Property<int?>("ServicoId");

                    b.HasKey("OrdemId");

                    b.HasIndex("CustomizarId");

                    b.HasIndex("ServicoId");

                    b.ToTable("Ordem");
                });

            modelBuilder.Entity("PetShopMVC.Models.OrdemDetalhe", b =>
                {
                    b.Property<int>("OrdemDetalheId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomizarId");

                    b.Property<int>("OrdemId");

                    b.Property<int>("OrdemStatus");

                    b.Property<decimal>("Preco");

                    b.Property<int>("ServicoId");

                    b.Property<string>("ServicoName");

                    b.HasKey("OrdemDetalheId");

                    b.HasIndex("CustomizarId");

                    b.HasIndex("OrdemId");

                    b.HasIndex("ServicoId");

                    b.ToTable("OrdemDetalhe");
                });

            modelBuilder.Entity("PetShopMVC.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<decimal>("Preco");

                    b.HasKey("Id");

                    b.ToTable("Servico");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Servico");
                });

            modelBuilder.Entity("PetShopMVC.Models.ServicoOrdem", b =>
                {
                    b.HasBaseType("PetShopMVC.Models.Servico");

                    b.Property<string>("Animal");

                    b.Property<int?>("CustomizarId");

                    b.Property<int>("ServicoId");

                    b.HasIndex("CustomizarId");

                    b.HasIndex("ServicoId");

                    b.ToTable("ServicoOrdem");

                    b.HasDiscriminator().HasValue("ServicoOrdem");
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

            modelBuilder.Entity("PetShopMVC.Models.Ordem", b =>
                {
                    b.HasOne("PetShopMVC.Models.Customizar", "Customizar")
                        .WithMany("Ordem")
                        .HasForeignKey("CustomizarId");

                    b.HasOne("PetShopMVC.Models.Servico")
                        .WithMany("Ordem")
                        .HasForeignKey("ServicoId");
                });

            modelBuilder.Entity("PetShopMVC.Models.OrdemDetalhe", b =>
                {
                    b.HasOne("PetShopMVC.Models.Customizar", "Customizar")
                        .WithMany("OrdemDetalhe")
                        .HasForeignKey("CustomizarId");

                    b.HasOne("PetShopMVC.Models.Ordem", "Ordem")
                        .WithMany("OrdemDetalhe")
                        .HasForeignKey("OrdemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetShopMVC.Models.Servico", "Servico")
                        .WithMany("OrdemDetalhe")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetShopMVC.Models.ServicoOrdem", b =>
                {
                    b.HasOne("PetShopMVC.Models.Customizar")
                        .WithMany("ServicoOrdem")
                        .HasForeignKey("CustomizarId");

                    b.HasOne("PetShopMVC.Models.Servico")
                        .WithMany("ServicoOrdem")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}