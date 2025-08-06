namespace Genesis.Shared.DTOs.Medico;

public class MedicoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CRM { get; set; } = string.Empty;
    public string Especialidade { get; set; } = string.Empty;
}