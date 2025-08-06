using Genesis.Application.Features.Medico.Commands;
using Genesis.Domain.Repositories;
using MediatR;

namespace Genesis.Application.Features.Medico.Handlers;

public class UpdateMedicoHandler : IRequestHandler<UpdateMedicoCommand, bool>
{
    private readonly IMedicoRepository _repository;

    public UpdateMedicoHandler(IMedicoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateMedicoCommand request, CancellationToken cancellationToken)
    {
        var medico = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (medico is null) return false;

        medico.Nome = request.Dto.Nome;
        medico.CRM = request.Dto.CRM;
        medico.Especialidade = request.Dto.Especialidade;

        return await _repository.UpdateAsync(medico, cancellationToken);
    }
}