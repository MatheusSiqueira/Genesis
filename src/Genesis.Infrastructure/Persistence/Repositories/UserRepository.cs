using Genesis.Domain.Entities;
using Genesis.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly GenesisDbContext _context;

    public UserRepository(GenesisDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
    }
}