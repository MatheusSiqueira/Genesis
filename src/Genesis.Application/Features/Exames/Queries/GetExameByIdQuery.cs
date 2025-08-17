using Genesis.Domain.Entities;
using MediatR;

namespace Genesis.Application.Features.Exames.Queries;

public record GetExameByIdQuery(Guid Id) : IRequest<Exame?>;