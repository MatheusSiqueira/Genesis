namespace Genesis.Domain.Entities;

public class Paciente
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}