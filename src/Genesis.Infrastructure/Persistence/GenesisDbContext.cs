using Genesis.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Infrastructure.Persistence;

public partial class GenesisDbContext : DbContext
{
    public GenesisDbContext(DbContextOptions<GenesisDbContext> options)
        : base(options) { }

    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<Medico> Medicos => Set<Medico>();
    public DbSet<User> Users => Set<User>();
    public DbSet<ErrorLog> ErrorLogs => Set<ErrorLog>();
    public DbSet<Exame> Exames { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public"); // PostgreSQL usa 'public' por padrão
        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            entity.Property(p => p.CPF).IsRequired().HasMaxLength(14);
            entity.Property(p => p.Email).HasMaxLength(100);
            entity.Property(p => p.DataNascimento).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }
}
