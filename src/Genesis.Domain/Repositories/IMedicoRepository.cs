using Genesis.Domain.Entities;

namespace Genesis.Domain.Repositories;

public interface IMedicoRepository
{
    Task<Medico?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Medico>> GetAllAsync(CancellationToken cancellationToken);
    Task<Guid> AddAsync(Medico medico, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Medico medico, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Medico medico, CancellationToken cancellationToken);
}