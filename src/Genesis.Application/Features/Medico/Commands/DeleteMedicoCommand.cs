using MediatR;

namespace Genesis.Application.Features.Medico.Commands;

public class DeleteMedicoCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteMedicoCommand(Guid id)
    {
        Id = id;
    }
}