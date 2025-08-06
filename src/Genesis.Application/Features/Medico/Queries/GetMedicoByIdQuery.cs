using Genesis.Shared.DTOs.Medico;
using MediatR;

namespace Genesis.Application.Features.Medico.Queries;

public class GetMedicoByIdQuery : IRequest<MedicoDto>
{
    public Guid Id { get; }

    public GetMedicoByIdQuery(Guid id)
    {
        Id = id;
    }
}