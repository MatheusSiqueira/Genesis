using Genesis.Domain.Entities;
using Genesis.Domain.Enums;
using Genesis.Domain.Repositories;
using Genesis.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Genesis.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;
    private readonly IUserRepository _userRepository;

    public AuthController(JwtService jwtService, IUserRepository userRepository)
    {
        _jwtService = jwtService;
        _userRepository = userRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var existingUser = await _userRepository.GetByUsernameAsync(request.Username, CancellationToken.None);
        if (existingUser != null)
            return BadRequest("Usuário já existe.");

        var user = new User
        {
            Username = request.Username,
            PasswordHash = HashPassword(request.Password),
            Role = request.Role
        };

        await _userRepository.AddAsync(user, CancellationToken.None);

        return Ok("Usuário registrado com sucesso.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username, CancellationToken.None);
        if (user == null || user.PasswordHash != HashPassword(request.Password))
            return Unauthorized("Usuário ou senha inválidos.");

        var token = _jwtService.GenerateToken(user);
        return Ok(new { token });
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
}

public class RegisterRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; }
}

public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
