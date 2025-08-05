using Genesis.Domain.Entities;

namespace Genesis.Domain.Repositories;

public interface IPacienteRepository
{
    Task<Guid> AddAsync(Paciente paciente, CancellationToken cancellationToken);
    Task<Paciente?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Paciente>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Paciente paciente, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Paciente paciente, CancellationToken cancellationToken);
}