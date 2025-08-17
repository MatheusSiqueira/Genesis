
using Genesis.Domain.Enums;
using MediatR;
namespace Genesis.Application.Features.Exames.Commands;
public record UpdateExameStatusCommand(Guid Id, ExameStatus Status, DateTime? DataAnalise) : IRequest<bool>;
