using Genesis.Shared.DTOs.Paciente;
using MediatR;

namespace Genesis.Application.Features.Pacientes.Queries;

public class GetPacienteByIdQuery : IRequest<PacienteDto>
{
    public Guid Id { get; }

    public GetPacienteByIdQuery(Guid id)
    {
        Id = id;
    }
}