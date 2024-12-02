﻿// <auto-generated />
using System;
using ApiCrud.src.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiCrud.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241128020427_arrumandoFK")]
    partial class arrumandoFK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Interfocus.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("IdCidade")
                        .HasColumnType("integer");

                    b.Property<int>("IdContrato")
                        .HasColumnType("integer");

                    b.Property<int?>("IdEstado")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Interfocus.Models.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("integer");

                    b.Property<int>("IdEquipamento")
                        .HasColumnType("integer");

                    b.Property<int>("StatusContrato")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("Contrato");
                });

            modelBuilder.Entity("Interfocus.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("Interfocus.Models.Ocorrencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Anexo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "anexo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "descricao");

                    b.HasKey("Id");

                    b.ToTable("Ocorrencias");
                });

            modelBuilder.Entity("Interfocus.Models.OcorrenciaOS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IdOcorrencia")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id_ocorrencia");

                    b.Property<int>("IdOrdemServico")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id_os");

                    b.HasKey("Id");

                    b.HasIndex("IdOcorrencia");

                    b.HasIndex("IdOrdemServico");

                    b.ToTable("OcorrenciasOS", (string)null);
                });

            modelBuilder.Entity("Interfocus.Models.OrdemServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("timestamp with time zone")
                        .HasAnnotation("Relational:JsonPropertyName", "data_agendamento");

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id_cliente");

                    b.Property<int>("IdContrato")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id_contrato");

                    b.Property<int>("IdFuncionarioAbriu")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "funcionario_abriu");

                    b.Property<int?>("IdFuncionarioFechou")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "funcionario_fechou");

                    b.Property<int>("IdStatusOS")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id_status_os");

                    b.Property<int>("IdTipoServico")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id_tipo_servico");

                    b.HasKey("Id");

                    b.HasIndex("IdStatusOS");

                    b.ToTable("OrdensServico");
                });

            modelBuilder.Entity("Interfocus.Models.Plano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Combo")
                        .HasColumnType("boolean");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdTipo")
                        .HasColumnType("integer");

                    b.Property<int>("Tier")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdTipo");

                    b.ToTable("Plano");
                });

            modelBuilder.Entity("Interfocus.Models.StatusOS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "descricao");

                    b.HasKey("Id");

                    b.ToTable("StatusOS");
                });

            modelBuilder.Entity("Interfocus.Models.TipoPlano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TipoPlano");
                });

            modelBuilder.Entity("Interfocus.Models.TipoServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("MudancaContrato")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "mudanca_contrato");

                    b.Property<int>("StatusCt")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "status_ct");

                    b.HasKey("Id");

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
                    b.HasOne("Interfocus.Models.Ocorrencia", null)
                        .WithMany()
                        .HasForeignKey("IdOcorrencia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interfocus.Models.OrdemServico", null)
                        .WithMany()
                        .HasForeignKey("IdOrdemServico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Interfocus.Models.OrdemServico", b =>
                {
                    b.HasOne("Interfocus.Models.StatusOS", null)
                        .WithMany()
                        .HasForeignKey("IdStatusOS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("Interfocus.Models.Cliente", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("Interfocus.Models.TipoPlano", b =>
                {
                    b.Navigation("Planos");
                });
#pragma warning restore 612, 618
        }
    }
}
