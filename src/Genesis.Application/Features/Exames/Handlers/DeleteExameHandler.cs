using Genesis.Application.Features.Exames.Commands;
using Genesis.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Application.Features.Exames.Handlers;

public class DeleteExameHandler : IRequestHandler<DeleteExameCommand, bool>
{
    private readonly GenesisDbContext _db;
    public DeleteExameHandler(GenesisDbContext db) => _db = db;

    public async Task<bool> Handle(DeleteExameCommand request, CancellationToken cancellationToken)
    {
        var exame = await _db.Exames.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        if (exame == null) return false;

        exame.IsDeleted = true;
        exame.UpdatedAt = DateTime.UtcNow;
        exame.UpdatedBy = request.DeletedBy;

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}