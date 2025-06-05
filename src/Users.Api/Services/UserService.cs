using Microsoft.EntityFrameworkCore;
using Users.Api.Data;
using Users.Api.Domain.Users;

namespace Users.Api.Services;

public class UserService(UsersDbContext dbContext)
{
    private readonly UsersDbContext _dbContext = dbContext;

    public async Task<IEnumerable<User>> GetAllUsersAsync() =>
        await _dbContext.Users.ToListAsync();

    public async Task<User?> GetUserByIdAsync(Guid id) =>
        await _dbContext.Users.FindAsync(id);

    public async Task<User> RegisterUserAsync(User user)
    {
        user.Id = Guid.NewGuid();
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> UpdateUserAsync(Guid id, User updatedUser)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user is null) return null;

        user.FirstName = updatedUser.FirstName;
        user.LastName = updatedUser.LastName;
        user.Email = updatedUser.Email;

        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(Guid id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user is null) return false;

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
