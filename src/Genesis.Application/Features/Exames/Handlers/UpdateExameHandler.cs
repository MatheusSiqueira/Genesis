using Genesis.Application.Features.Exames.Commands;
using Genesis.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Application.Features.Exames.Handlers;

public class UpdateExameHandler : IRequestHandler<UpdateExameCommand, bool>
{
    private readonly GenesisDbContext _db;
    public UpdateExameHandler(GenesisDbContext db) => _db = db;

    public async Task<bool> Handle(UpdateExameCommand request, CancellationToken cancellationToken)
    {
        var exame = await _db.Exames.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        if (exame == null) return false;

        exame.Tipo = request.Tipo;
        exame.Status = request.Status;
        exame.DataSolicitacao = request.DataSolicitacao;
        exame.UpdatedAt = DateTime.UtcNow;
        exame.UpdatedBy = request.UpdatedBy;

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}