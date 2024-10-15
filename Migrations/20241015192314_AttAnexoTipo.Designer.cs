﻿// <auto-generated />
using System;
using ApiCrud.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiCrud.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241015192314_AttAnexoTipo")]
    partial class AttAnexoTipo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Interfocus.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdCidade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdContrato")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IdEstado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Interfocus.Models.Contrato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdCliente")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdEndereco")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdEquipamento")
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusContrato")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("Interfocus.Models.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Interfocus.Models.Ocorrencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Anexo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ocorrencias");
                });

            modelBuilder.Entity("Interfocus.Models.OcorrenciaOS", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdOcorrencia")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdOrdemServico")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdOcorrencia");

                    b.HasIndex("IdOrdemServico");

                    b.ToTable("OcorrenciasOS");
                });

            modelBuilder.Entity("Interfocus.Models.OrdemServico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdCliente")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdContrato")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdFuncionarioAbriu")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("IdFuncionarioFechou")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdStatusOS")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdTipoServico")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdStatusOS");

                    b.ToTable("OrdensServico");
                });

            modelBuilder.Entity("Interfocus.Models.Plano", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Combo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdTipo")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Tier")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdTipo");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("Interfocus.Models.StatusOS", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrdemServicoId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrdemServicoId");

                    b.ToTable("StatusOS");
                });

            modelBuilder.Entity("Interfocus.Models.TipoPlano", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TiposPlano");
                });

            modelBuilder.Entity("Interfocus.Models.TipoServico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdContrato")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdContrato");

                    b.ToTable("TiposServico");
                });

            modelBuilder.Entity("Interfocus.Models.Contrato", b =>
                {
                    b.HasOne("Interfocus.Models.Cliente", "Cliente")
                        .WithMany("Contratos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Interfocus.Models.OcorrenciaOS", b =>
                {
                    b.HasOne("Interfocus.Models.Ocorrencia", "Ocorrencia")
                        .WithMany()
                        .HasForeignKey("IdOcorrencia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interfocus.Models.OrdemServico", "OrdemServico")
                        .WithMany("OcorrenciasOS")
                        .HasForeignKey("IdOrdemServico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ocorrencia");

                    b.Navigation("OrdemServico");
                });

            modelBuilder.Entity("Interfocus.Models.OrdemServico", b =>
                {
                    b.HasOne("Interfocus.Models.StatusOS", "StatusOS")
                        .WithMany()
                        .HasForeignKey("IdStatusOS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusOS");
                });

            modelBuilder.Entity("Interfocus.Models.Plano", b =>
                {
                    b.HasOne("Interfocus.Models.TipoPlano", "TipoPlano")
                        .WithMany("Planos")
                        .HasForeignKey("IdTipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPlano");
                });

            modelBuilder.Entity("Interfocus.Models.StatusOS", b =>
                {
                    b.HasOne("Interfocus.Models.OrdemServico", "OrdemServico")
                        .WithMany()
                        .HasForeignKey("OrdemServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdemServico");
                });

            modelBuilder.Entity("Interfocus.Models.TipoServico", b =>
                {
                    b.HasOne("Interfocus.Models.Contrato", "Contrato")
                        .WithMany()
                        .HasForeignKey("IdContrato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrato");
                });

            modelBuilder.Entity("Interfocus.Models.Cliente", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("Interfocus.Models.OrdemServico", b =>
                {
                    b.Navigation("OcorrenciasOS");
                });

            modelBuilder.Entity("Interfocus.Models.TipoPlano", b =>
                {
                    b.Navigation("Planos");
                });
#pragma warning restore 612, 618
        }
    }
}
