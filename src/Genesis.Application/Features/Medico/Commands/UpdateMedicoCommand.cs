using Genesis.Shared.DTOs.Medico;
using Genesis.Shared.DTOs.Paciente;
using MediatR;

namespace Genesis.Application.Features.Medico.Commands;

public class UpdateMedicoCommand : IRequest<bool>
{
    public Guid Id { get; }
    public UpdateMedicoDto Dto { get; }

    public UpdateMedicoCommand(Guid id, UpdateMedicoDto dto)
    {
        Id = id;
        Dto = dto;
    }
}