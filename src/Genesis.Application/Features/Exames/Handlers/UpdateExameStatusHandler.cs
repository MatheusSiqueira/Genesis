using Genesis.Application.Features.Exames.Commands;
using Genesis.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Application.Features.Exames.Handlers;

public sealed class UpdateExameStatusHandler
    : IRequestHandler<UpdateExameStatusCommand, bool>
{
    private readonly GenesisDbContext _db;

    public UpdateExameStatusHandler(GenesisDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(UpdateExameStatusCommand r, CancellationToken ct)
    {
        var e = await _db.Exames.FirstOrDefaultAsync(x => x.Id == r.Id, ct);
        if (e is null) return false;

        e.Status = r.Status;
        e.DataAnalise = r.DataAnalise ?? e.DataAnalise;

        await _db.SaveChangesAsync(ct);
        return true;
    }
}