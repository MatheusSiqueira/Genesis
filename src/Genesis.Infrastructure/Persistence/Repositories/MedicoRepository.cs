using Genesis.Domain.Entities;
using Genesis.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Infrastructure.Persistence.Repositories;

public class MedicoRepository : IMedicoRepository
{
    private readonly GenesisDbContext _context;

    public MedicoRepository(GenesisDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(Medico medico, CancellationToken cancellationToken)
    {
        _context.Medicos.Add(medico);
        await _context.SaveChangesAsync(cancellationToken);
        return medico.Id;
    }

    public async Task<bool> DeleteAsync(Medico medico, CancellationToken cancellationToken)
    {
        _context.Medicos.Remove(medico);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<Medico>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Medicos.ToListAsync(cancellationToken);
    }

    public async Task<Medico?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Medicos.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<bool> UpdateAsync(Medico medico, CancellationToken cancellationToken)
    {
        _context.Medicos.Update(medico);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken ct)
        => _context.Pacientes.AnyAsync(p => p.Id == id, ct);
}