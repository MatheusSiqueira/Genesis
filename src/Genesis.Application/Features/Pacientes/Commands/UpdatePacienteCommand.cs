using Genesis.Shared.DTOs.Paciente;
using MediatR;

namespace Genesis.Application.Features.Pacientes.Commands;

public class UpdatePacienteCommand : IRequest<bool>
{
    public Guid Id { get; }
    public UpdatePacienteDto Dto { get; }

    public UpdatePacienteCommand(Guid id, UpdatePacienteDto dto)
    {
        Id = id;
        Dto = dto;
    }
}