using Genesis.Application.Features.Exames.Commands;
using Genesis.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Application.Features.Exames.Handlers;

public sealed class AttachExameResultadoHandler
    : IRequestHandler<AttachExameResultadoCommand, bool>
{
    private readonly GenesisDbContext _db;

    public AttachExameResultadoHandler(GenesisDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(AttachExameResultadoCommand r, CancellationToken ct)
    {
        var e = await _db.Exames.FirstOrDefaultAsync(x => x.Id == r.Id, ct);
        if (e == null)
            return false;

        e.ResultadoResumo = r.ResultadoResumo;
        e.ResultadoArquivo = r.ResultadoArquivoUrl;

        await _db.SaveChangesAsync(ct);
        return true;
    }
}