namespace Genesis.Domain.Entities;

public class Paciente : AuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    public DateOnly? DataNascimento { get; set; }
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DataCadastro { get; set; }
    public List<Exame> Exames { get; set; } = new();
}