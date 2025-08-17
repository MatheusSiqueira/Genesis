using Genesis.Domain.Enums;
using MediatR;

namespace Genesis.Application.Features.Exames.Commands;

public record UpdateExameCommand(
    Guid Id,
    string Tipo,
    ExameStatus Status,
    DateTime DataSolicitacao,
    string UpdatedBy
) : IRequest<bool>;