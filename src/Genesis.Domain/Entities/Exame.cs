using Genesis.Domain.Enums;

namespace Genesis.Domain.Entities
{
    public class Exame
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public ExameStatus Status { get; set; } = ExameStatus.Pendente;

        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; } = null!;

        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; } = null!;

        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataAnalise { get; set; }

        public string? ResultadoResumo { get; set; } // resumo textual do resultado
        public string? ResultadoArquivo { get; set; } // caminho ou base64 do arquivo

        // Auditoria
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}