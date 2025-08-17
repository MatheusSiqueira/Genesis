using Genesis.Application.Features.Exames.Queries;
using Genesis.Domain.Entities;
using Genesis.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Application.Features.Exames.Handlers;

public class ListExamesHandler : IRequestHandler<ListExamesQuery, List<Exame>>
{
    private readonly GenesisDbContext _db;
    public ListExamesHandler(GenesisDbContext db) => _db = db;

    public async Task<List<Exame>> Handle(ListExamesQuery request, CancellationToken cancellationToken)
    {
        return await _db.Exames
            .Include(e => e.Paciente)
            .Include(e => e.Medico)
            .OrderByDescending(e => e.CreatedAt)
            .ToListAsync(cancellationToken);
    }
}