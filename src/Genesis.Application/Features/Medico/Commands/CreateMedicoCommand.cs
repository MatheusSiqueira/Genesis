using Genesis.Shared.DTOs.Medico;
using MediatR;

namespace Genesis.Application.Features.Medico.Commands;

public class CreateMedicoCommand : IRequest<Guid>
{
    public CreateMedicoDto Dto { get; }

    public CreateMedicoCommand(CreateMedicoDto dto)
    {
        Dto = dto;
    }
}