using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Genesis.Infrastructure.Persistence
{
    public class GenesisDbContextFactory : IDesignTimeDbContextFactory<GenesisDbContext>
    {
        public GenesisDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Host=aws-0-sa-east-1.pooler.supabase.com;Port=5432;Username=postgres.pzcoztupexympwvkvppd;Password=Genesis123;Database=postgres;SSL Mode=Require;Trust Server Certificate=true;Timeout=60;Command Timeout=60";

            var optionsBuilder = new DbContextOptionsBuilder<GenesisDbContext>();

            optionsBuilder.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.CommandTimeout(60);
            });

            return new GenesisDbContext(optionsBuilder.Options);
        }
    }
}