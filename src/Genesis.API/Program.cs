using Genesis.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddSwaggerConfiguration();

// JWT
builder.Services.AddJwtConfiguration(builder.Configuration);

// CORS
builder.Services.AddCorsConfiguration();

// Injeção de dependências do projeto
builder.Services.AddProjectServices(builder.Configuration);

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Pipeline
app.UseHttpsRedirection();
app.UseCors(); // ⚠️ Importante: deve vir antes do Authentication
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();