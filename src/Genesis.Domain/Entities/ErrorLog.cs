using System;

namespace Genesis.Domain.Entities
{
    public class ErrorLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string StackTrace { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty; // usuário logado ou "Anon"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}