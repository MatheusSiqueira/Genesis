namespace Genesis.Shared.DTOs.Paciente;

public class CreatePacienteDto
{
    public string Nome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}