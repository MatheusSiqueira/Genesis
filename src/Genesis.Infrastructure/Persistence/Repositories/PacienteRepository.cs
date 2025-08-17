using Genesis.Domain.Entities;
using Genesis.Domain.Repositories;
using Genesis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Infrastructure.Persistence.Repositories;

public class PacienteRepository : IPacienteRepository
{
    private readonly GenesisDbContext _context;

    public PacienteRepository(GenesisDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(Paciente paciente, CancellationToken cancellationToken)
    {
        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync(cancellationToken);
        return paciente.Id;
    }

    public async Task<Paciente?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Pacientes.FindAsync(new object[] { id }, cancellationToken);
    }
    public async Task<List<Paciente>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Pacientes.ToListAsync(cancellationToken);
    }

    public async Task<bool> UpdateAsync(Paciente paciente, CancellationToken cancellationToken)
    {
        _context.Pacientes.Update(paciente);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    public async Task<bool> DeleteAsync(Paciente paciente, CancellationToken cancellationToken)
    {
        _context.Pacientes.Remove(paciente);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    public Task<bool> ExistsAsync(Guid id, CancellationToken ct)
        => _context.Pacientes.AnyAsync(p => p.Id == id, ct);
}