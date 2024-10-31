using System;
using Microsoft.EntityFrameworkCore;
using Interfocus.Models;

namespace ApiCrud.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<TipoPlano> TiposPlano { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<OcorrenciaOS> OcorrenciasOS { get; set; }
        public DbSet<StatusOS> StatusOS { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<TipoServico> TiposServico { get; set; }
        public DbSet<OrdemServico> OrdensServico { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*optionsBuilder.UseSqlite("Data Source=Banco.sqlite")*/
            optionsBuilder.UseNpgsql("Host=localhost;Database=interfocus;Username=postgres;Password=qwerty");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureCliente();
            modelBuilder.ConfigureContrato();
            modelBuilder.ConfigurePlano();
            modelBuilder.ConfigureTipoPlano();
            modelBuilder.ConfigureOcorrencia();
            modelBuilder.ConfigureOcorrenciaOS();
            modelBuilder.ConfigureStatusOS();
            modelBuilder.ConfigureFuncionario();
            modelBuilder.ConfigureTipoServico();
            modelBuilder.ConfigureOrdemServico();
        }
    }
}
