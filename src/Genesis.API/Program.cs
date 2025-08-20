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

// DI do projeto
builder.Services.AddProjectServices(builder.Configuration);

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
app.UseCors(CorsConfiguration.PolicyName);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();