using Genesis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Genesis.Infrastructure.Persistence;
public partial class GenesisDbContext : DbContext
{
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;
        foreach (var e in ChangeTracker.Entries<AuditableEntity>())
        {
            if (e.State == EntityState.Added)
            {
                e.Entity.CreatedAt = now;
                if (e.Entity is Paciente p && p.DataCadastro == default) p.DataCadastro = now;
            }
            else if (e.State == EntityState.Modified)
            {
                e.Entity.UpdatedAt = now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
