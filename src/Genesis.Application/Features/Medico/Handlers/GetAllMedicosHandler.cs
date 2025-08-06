using Genesis.Application.Features.Medico.Queries;
using Genesis.Domain.Repositories;
using Genesis.Shared.DTOs.Medico;
using MediatR;

namespace Genesis.Application.Features.Medico.Handlers;

public class GetAllMedicosHandler : IRequestHandler<GetAllMedicosQuery, List<MedicoDto>>
{
    private readonly IMedicoRepository _repository;

    public GetAllMedicosHandler(IMedicoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MedicoDto>> Handle(GetAllMedicosQuery request, CancellationToken cancellationToken)
    {
        var medico = await _repository.GetAllAsync(cancellationToken);

        return medico.Select(p => new MedicoDto
        {
            Id = p.Id,
            Nome = p.Nome,
            CRM = p.CRM,
        }).ToList();
    }
}