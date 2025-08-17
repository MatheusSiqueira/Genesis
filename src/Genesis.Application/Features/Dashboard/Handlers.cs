using Genesis.Application.Features.Dashboard.Queries;
using Genesis.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Genesis.Application.Features.Dashboard;
public sealed class GetDashboardSummaryHandler
    : IRequestHandler<GetDashboardSummaryQuery, DashboardSummary>
{
    private readonly GenesisDbContext _db;

    public GetDashboardSummaryHandler(GenesisDbContext db)
    {
        _db = db;
    }

    public async Task<DashboardSummary> Handle(GetDashboardSummaryQuery request, CancellationToken ct)
    {
        var now = DateTime.UtcNow;
        var seven = now.AddDays(-7);

        var pacientes = await _db.Pacientes.CountAsync(ct);
        var exames = await _db.Exames.CountAsync(ct);
        var medicos = await _db.Medicos.CountAsync(ct);
        var deltaPac = await _db.Pacientes.CountAsync(x => x.CreatedAt >= seven, ct);
        var deltaEx = await _db.Exames.CountAsync(x => x.CreatedAt >= seven, ct);

        return new DashboardSummary(pacientes, exames, medicos, deltaPac, deltaEx);
    }
}

