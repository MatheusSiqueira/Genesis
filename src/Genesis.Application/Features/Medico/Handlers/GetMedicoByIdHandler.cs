using Genesis.Application.Features.Medico.Queries;
using Genesis.Domain.Repositories;
using Genesis.Shared.DTOs.Medico;
using MediatR;

namespace Genesis.Application.Features.Medico.Handlers;

public class GetMedicoByIdHandler : IRequestHandler<GetMedicoByIdQuery, MedicoDto?>
{
    private readonly IMedicoRepository _repository;

    public GetMedicoByIdHandler(IMedicoRepository repository)
    {
        _repository = repository;
    }

    public async Task<MedicoDto?> Handle(GetMedicoByIdQuery request, CancellationToken cancellationToken)
    {
        var medico = await _repository.GetByIdAsync(request.Id, cancellationToken);

        return medico == null ? null : new MedicoDto
        {
            Id = medico.Id,
            Nome = medico.Nome,
            CRM = medico.CRM,
        };
    }
}