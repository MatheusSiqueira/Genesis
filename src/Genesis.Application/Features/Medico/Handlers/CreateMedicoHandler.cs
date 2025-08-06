using Genesis.Application.Features.Medico.Commands;
using Genesis.Domain.Repositories;
using MediatR;

namespace Genesis.Application.Features.Medico.Handlers;

public class CreateMedicoHandler : IRequestHandler<CreateMedicoCommand, Guid>
{
    private readonly IMedicoRepository _repository;

    public CreateMedicoHandler(IMedicoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateMedicoCommand request, CancellationToken cancellationToken)
    {
        var medico = new Domain.Entities.Medico
        {
            Nome = request.Dto.Nome,
            CRM = request.Dto.CRM,
            Especialidade = request.Dto.Especialidade
        };

        return await _repository.AddAsync(medico, cancellationToken);
    }
}