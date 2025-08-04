using Genesis.Shared.DTOs.Paciente;
using MediatR;

namespace Genesis.Application.Features.Pacientes.Commands;

public class CreatePacienteCommand : IRequest<Guid>
{
    public CreatePacienteDto Dto { get; set; }

    public CreatePacienteCommand(CreatePacienteDto dto)
    {
        Dto = dto;
    }
}