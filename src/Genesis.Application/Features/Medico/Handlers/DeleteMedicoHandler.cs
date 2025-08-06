using Genesis.Application.Features.Medico.Commands;
using Genesis.Domain.Repositories;
using MediatR;

namespace Genesis.Application.Features.Medico.Handlers;

public class DeleteMedicoHandler : IRequestHandler<DeleteMedicoCommand, bool>
{
    private readonly IMedicoRepository _repository;

    public DeleteMedicoHandler(IMedicoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteMedicoCommand request, CancellationToken cancellationToken)
    {
        var medico = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (medico is null) return false;

        return await _repository.DeleteAsync(medico, cancellationToken);
    }
}