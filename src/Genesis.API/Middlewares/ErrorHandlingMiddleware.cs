using Genesis.Application.Common;
using Genesis.Domain.Entities;
using Genesis.Infrastructure.Persistence;
using System.Net;
using System.Security.Claims;
using System.Text.Json;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, GenesisDbContext db)
    {
        try
        {
            await _next(context);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Erro de negócio");
            await WriteErrorResponse(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogWarning(ex, "Recurso não encontrado");
            await WriteErrorResponse(context, HttpStatusCode.NotFound, ex.Message);
        }
        catch (Exception ex)
        {
            // Gerar código aleatório de 6 caracteres
            var errorCode = GenerateErrorCode();

            // Obter ID do usuário logado (se existir)
            var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Anon";

            // Log no console
            _logger.LogError(ex, $"Erro interno - Código: {errorCode} - Usuário: {userId}");

            // Gravar log no banco
            var errorLog = new ErrorLog
            {
                Code = errorCode,
                Message = ex.Message,
                StackTrace = ex.StackTrace ?? string.Empty,
                CreatedBy = userId // NOVO: registra o usuário
            };
            db.ErrorLogs.Add(errorLog);
            await db.SaveChangesAsync();

            // Mensagem amigável para o usuário
            await WriteErrorResponse(context, HttpStatusCode.InternalServerError,
                $"Ocorreu um erro interno. Contacte o suporte Código de referência: {errorCode}");
        }
    }

    private static string GenerateErrorCode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 6)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    private static async Task WriteErrorResponse(HttpContext context, HttpStatusCode statusCode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = ApiResponse<object>.Fail(message);
        var json = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(json);
    }
}
