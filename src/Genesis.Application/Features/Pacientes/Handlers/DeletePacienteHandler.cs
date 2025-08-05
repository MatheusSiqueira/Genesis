using Genesis.Application.Features.Pacientes.Commands;
using Genesis.Domain.Repositories;
using MediatR;

namespace Genesis.Application.Features.Pacientes.Handlers;

public class DeletePacienteHandler : IRequestHandler<DeletePacienteCommand, bool>
{
    private readonly IPacienteRepository _repository;

    public DeletePacienteHandler(IPacienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeletePacienteCommand request, CancellationToken cancellationToken)
    {
        var paciente = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (paciente is null) return false;

        return await _repository.DeleteAsync(paciente, cancellationToken);
    }
}