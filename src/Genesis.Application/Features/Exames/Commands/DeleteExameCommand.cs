using MediatR;

namespace Genesis.Application.Features.Exames.Commands;

public record DeleteExameCommand(Guid Id, string DeletedBy) : IRequest<bool>;