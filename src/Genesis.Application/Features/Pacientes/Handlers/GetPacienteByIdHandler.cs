using Genesis.Application.Features.Pacientes.Queries;
using Genesis.Domain.Repositories;
using Genesis.Shared.DTOs.Paciente;
using MediatR;

namespace Genesis.Application.Features.Pacientes.Handlers;

public class GetPacienteByIdHandler : IRequestHandler<GetPacienteByIdQuery, PacienteDto?>
{
    private readonly IPacienteRepository _repository;

    public GetPacienteByIdHandler(IPacienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<PacienteDto?> Handle(GetPacienteByIdQuery request, CancellationToken cancellationToken)
    {
        var paciente = await _repository.GetByIdAsync(request.Id, cancellationToken);

        return paciente == null ? null : new PacienteDto
        {
            Id = paciente.Id,
            Nome = paciente.Nome,
            Email = paciente.Email,
            CPF = paciente.CPF,
            DataNascimento = paciente.DataNascimento
        };
    }
}