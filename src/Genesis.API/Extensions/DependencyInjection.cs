using Genesis.Application.Features.Pacientes.Handlers;
using Genesis.Domain.Repositories;
using Genesis.Infrastructure.Persistence;
using Genesis.Infrastructure.Persistence.Repositories;
using Genesis.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Genesis.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration config)
    {
        // DbContext
        services.AddDbContext<GenesisDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

        // MediatR
        services.AddMediatR(typeof(CreatePacienteHandler).Assembly);

        // Repositories
        services.AddScoped<IPacienteRepository, PacienteRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Services
        services.AddScoped<JwtService>();

        return services;
    }
}