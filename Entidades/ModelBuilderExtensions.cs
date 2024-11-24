using Microsoft.EntityFrameworkCore;
using Interfocus.Models;

public static class ModelBuilderExtensions
{
    public static void ConfigureOcorrencia(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ocorrencia>(entity =>
        {
            entity.HasKey(o => o.Id);

            entity.Property(o => o.Descricao)
                .IsRequired();

            entity.Property(o => o.Anexo)
                .IsRequired();
        });
    }

    public static void ConfigureOcorrenciaOS(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OcorrenciaOS>(entity =>
        {
            entity.HasKey(o => o.Id);

            //entity.HasOne(o => o.Ocorrencia)
            //    .WithMany()
            //    .HasForeignKey(o => o.IdOcorrencia)
            //    .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne<OcorrenciaOS>()
                .WithMany()
                .HasForeignKey(o => o.IdOrdemServico)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne<Ocorrencia>()
               .WithMany()
               .HasForeignKey(o => o.IdOcorrencia)
               .OnDelete(DeleteBehavior.Cascade);
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
    public static void ConfigureTipoServico(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TipoServico>(entity =>
        {
            entity.HasKey(ts => ts.Id);

            entity.Property(ts => ts.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(ts => ts.Contrato)
                .WithMany()
                .HasForeignKey(ts => ts.IdContrato)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
    public static void ConfigureOrdemServico(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrdemServico>(entity =>
        {
            entity.HasKey(o => o.Id);

            entity.Property(o => o.DataAgendamento)
                .IsRequired();

            entity.HasOne(o => o.StatusOS)  
                .WithMany()                  
                .HasForeignKey(o => o.IdStatusOS) 
                .OnDelete(DeleteBehavior.Cascade); 

            entity.Property(o => o.IdFuncionarioFechou).IsRequired(false);
        });
    }
}
