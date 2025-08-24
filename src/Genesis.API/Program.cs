using Genesis.API.Extensions;
using Genesis.Application.Pacientes.Queries;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddSwaggerConfiguration();

// JWT
builder.Services.AddJwtConfiguration(builder.Configuration);

// DI do projeto
builder.Services.AddProjectServices(builder.Configuration);

builder.Services.AddMediatR(typeof(GetPacientesQuery).Assembly);

var app = builder.Build();

// Swagger (só em dev; se quiser em prod, mova para fora do if)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Pipeline
app.UseHttpsRedirection();

// ⚠️ CORS deve vir ANTES de Auth/Authorization
app.UseCors(policy => policy
        .WithOrigins(
            "https://lab-genesis.online",   // PROD (front)
            "https://www.lab-genesis.online", // se usar www
            "http://localhost:5173"         // DEV (Vite)
        )
        .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE", "OPTIONS")
        .WithHeaders("Content-Type", "Authorization", "X-Requested-With")
        .SetPreflightMaxAge(TimeSpan.FromHours(1))
// .AllowCredentials() // só se autenticar por COOKIE; com JWT no header, deixe SEM
);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();