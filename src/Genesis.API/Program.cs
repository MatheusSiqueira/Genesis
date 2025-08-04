using Genesis.Application.Features.Pacientes.Handlers;
using Genesis.Domain.Repositories;
using Genesis.Infrastructure.Persistence;
using Genesis.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GenesisDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(typeof(CreatePacienteHandler).Assembly);
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();

// Run app
var app = builder.Build();

// Ativar Swagger em dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // ✅ isso exibe a UI
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();