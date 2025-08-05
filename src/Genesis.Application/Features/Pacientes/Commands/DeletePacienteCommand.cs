using MediatR;

namespace Genesis.Application.Features.Pacientes.Commands;

public class DeletePacienteCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeletePacienteCommand(Guid id)
    {
        Id = id;
    }
}