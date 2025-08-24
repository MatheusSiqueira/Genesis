using Genesis.Infrastructure.Persistence;              
using Genesis.Shared.DTOs.Common;                      
using Genesis.Shared.DTOs.Paciente;                    
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Application.Pacientes.Queries;

public sealed record GetPacientesQuery(
    int Page = 1,
    int PageSize = 10,
    string? Q = null
) : IRequest<PagedResult<PacienteDto>>;

public sealed class GetPacientesQueryHandler
    : IRequestHandler<GetPacientesQuery, PagedResult<PacienteDto>>
{
    private readonly GenesisDbContext _db;             

    public GetPacientesQueryHandler(GenesisDbContext db)
    {
        _db = db;
    }

    public async Task<PagedResult<PacienteDto>> Handle(GetPacientesQuery request, CancellationToken ct)
    {
        var page = request.Page <= 0 ? 1 : request.Page;
        var pageSize = request.PageSize <= 0 ? 10 : request.PageSize;
        if (pageSize > 200) pageSize = 200; // proteção básica

        // base query
        var query = _db.Pacientes.AsNoTracking().AsQueryable();

        // filtro (busca simples por nome/cpf/email)
        if (!string.IsNullOrWhiteSpace(request.Q))
        {
            var term = request.Q.Trim().ToLower();

            // Se você usa Npgsql/EFCore8 pode trocar para EF.Functions.ILike(...)
            query = query.Where(p =>
                p.Nome.ToLower().Contains(term) ||
                p.CPF.ToLower().Contains(term) ||
                (p.Email != null && p.Email.ToLower().Contains(term))
            );
        }

        // total antes do Skip/Take
        var total = await query.CountAsync(ct);

        // ordenação (padrão Nome, depois Id)
        query = query.OrderBy(p => p.Nome).ThenBy(p => p.Id);

        // paginação
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new PacienteDto
            {
                Id = p.Id,
                Nome = p.Nome,
                CPF = p.CPF,
                Email = p.Email,
                DataNascimento = p.DataNascimento
            })
            .ToListAsync(ct);

        return new PagedResult<PacienteDto>
        {
            Items = items,
            Total = total,
            Page = page,
            PageSize = pageSize
        };
    }
}
