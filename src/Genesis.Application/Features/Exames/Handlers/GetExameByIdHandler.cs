using Genesis.Application.Features.Exames.Queries;
using Genesis.Domain.Entities;
using Genesis.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Application.Features.Exames.Handlers;

public class GetExameByIdHandler : IRequestHandler<GetExameByIdQuery, Exame?>
{
    private readonly GenesisDbContext _db;
    public GetExameByIdHandler(GenesisDbContext db) => _db = db;

    public async Task<Exame?> Handle(GetExameByIdQuery request, CancellationToken cancellationToken)
    {
        return await _db.Exames
            .Include(e => e.Paciente)
            .Include(e => e.Medico)
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
    }
}