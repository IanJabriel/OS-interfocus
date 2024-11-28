using Microsoft.EntityFrameworkCore;
using Interfocus.Models;

public static class ModelBuilderExtensions
{
    public static void ConfigureCliente(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasMany(c => c.Contratos)
                .WithOne(c => c.Cliente)
                .HasForeignKey(c => c.IdCliente)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    public static void ConfigureContrato(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.StatusContrato)
                .IsRequired();
        });
    }

    public static void ConfigurePlano(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plano>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Descricao)
                .IsRequired();

            entity.Property(p => p.Combo)
                .IsRequired();

            entity.HasOne(p => p.TipoPlano)
                .WithMany(t => t.Planos)
                .HasForeignKey(p => p.IdTipo)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    public static void ConfigureTipoPlano(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TipoPlano>(entity =>
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Descricao)
                .IsRequired();
        });
    }

    public static void ConfigureOcorrencia(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ocorrencia>(entity =>
        {
            entity.HasKey(o => o.Id);

            entity.Property(o => o.Descricao)
                .IsRequired();

            entity.Property(o => o.Anexo)
                .IsRequired();

            entity.Property(o => o.Id)
                .ValueGeneratedOnAdd();
        });
    }

    public static void ConfigureOcorrenciaOS(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OcorrenciaOS>(entity =>
        {
            entity.HasKey(o => o.Id);

            entity.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            entity.HasOne<OrdemServico>()
                .WithMany()
                .HasForeignKey(o => o.IdOrdemServico)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            entity.HasOne<Ocorrencia>()
                .WithMany()
                .HasForeignKey(o => o.IdOcorrencia)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            entity.ToTable("OcorrenciasOS");
        });
    }



    public static void ConfigureStatusOS(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StatusOS>(entity =>
        {
            entity.HasKey(s => s.Id);

            entity.Property(s => s.Descricao)
                .IsRequired();
        });
    }

    public static void ConfigureFuncionario(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(f => f.Id);
        });
    }

    public static void ConfigureTipoServico(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TipoServico>(entity =>
        {
            entity.HasKey(ts => ts.Id);

            entity.Property(ts => ts.Descricao)
                .IsRequired()
                .HasMaxLength(100);

         
            entity.Property(ts => ts.StatusCt)
                .IsRequired();

            entity.Property(ts => ts.Id)
                .ValueGeneratedOnAdd(); 
        });
    }

    public static void ConfigureOrdemServico(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrdemServico>(entity =>
        {
            entity.HasKey(o => o.Id);

            entity.Property(o => o.DataAgendamento)
                .IsRequired();

            entity.HasOne<StatusOS>()
                .WithMany()
                .HasForeignKey(o => o.IdStatusOS)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(o => o.IdFuncionarioFechou).IsRequired(false);
        });
    }
}
