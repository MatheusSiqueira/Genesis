namespace Genesis.Shared.DTOs.Paciente;

public class PacienteDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateOnly? DataNascimento { get; set; }
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}