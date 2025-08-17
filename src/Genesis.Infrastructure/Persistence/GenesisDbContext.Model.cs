using Genesis.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Infrastructure.Persistence;
public partial class GenesisDbContext : DbContext
{
    protected void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paciente>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Exame>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Exame>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Tipo).IsRequired().HasMaxLength(100);
            entity.Property(x => x.ResultadoResumo).HasMaxLength(1000);
            entity.Property(x => x.ResultadoArquivo).HasMaxLength(500);
            entity.HasIndex(x => new { x.PacienteId, x.Status });
            entity.HasOne(x => x.Paciente).WithMany(p => p.Exames).HasForeignKey(x => x.PacienteId);
            entity.HasOne(x => x.Medico).WithMany().HasForeignKey(x => x.MedicoId);
        });
    }
}
