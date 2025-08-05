using Genesis.Application.Features.Pacientes.Queries;
using Genesis.Domain.Repositories;
using Genesis.Shared.DTOs.Paciente;
using MediatR;

namespace Genesis.Application.Features.Pacientes.Handlers;

public class GetAllPacientesHandler : IRequestHandler<GetAllPacientesQuery, List<PacienteDto>>
{
    private readonly IPacienteRepository _repository;

    public GetAllPacientesHandler(IPacienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<PacienteDto>> Handle(GetAllPacientesQuery request, CancellationToken cancellationToken)
    {
        var pacientes = await _repository.GetAllAsync(cancellationToken);

        return pacientes.Select(p => new PacienteDto
        {
            Id = p.Id,
            Nome = p.Nome,
            CPF = p.CPF,
            Email = p.Email,
            DataNascimento = p.DataNascimento
        }).ToList();
    }
}