using Genesis.Application.Features.Pacientes.Commands;
using Genesis.Domain.Repositories;
using MediatR;

namespace Genesis.Application.Features.Pacientes.Handlers;

public class UpdatePacienteHandler : IRequestHandler<UpdatePacienteCommand, bool>
{
    private readonly IPacienteRepository _repository;

    public UpdatePacienteHandler(IPacienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdatePacienteCommand request, CancellationToken cancellationToken)
    {
        var paciente = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (paciente is null) return false;

        paciente.Nome = request.Dto.Nome;
        paciente.CPF = request.Dto.CPF;
        paciente.Email = request.Dto.Email;
        paciente.DataNascimento = request.Dto.DataNascimento;

        return await _repository.UpdateAsync(paciente, cancellationToken);
    }
}