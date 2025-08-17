using Genesis.Domain.Enums;
using MediatR;

namespace Genesis.Application.Features.Exames.Commands
{
    public record CreateExameCommand(
        string Tipo,
        ExameStatus Status,
        Guid PacienteId,
        Guid MedicoId,
        DateTime DataSolicitacao,
        string CreatedBy
    ) : IRequest<Guid>;
}