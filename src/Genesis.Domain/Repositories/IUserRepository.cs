using Genesis.Domain.Entities;

namespace Genesis.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    Task AddAsync(User user, CancellationToken cancellationToken);
}