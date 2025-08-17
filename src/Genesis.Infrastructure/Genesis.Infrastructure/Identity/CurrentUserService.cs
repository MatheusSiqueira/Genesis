
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Genesis.Infrastructure.Identity;

public interface ICurrentUserService
{
    string? UserId { get; }
}

public sealed class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _http;
    public CurrentUserService(IHttpContextAccessor http) => _http = http;

    public string? UserId =>
        _http.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
        ?? _http.HttpContext?.User?.Identity?.Name;
}
