using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.User;

internal class UserRepository(DbContext context) : IUserRepository
{
    public async Task CreateUserAsync(Model.User user, CancellationToken cancellationToken = default)
    {
        user.CreatedAt = DateTime.UtcNow;
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Model.User?> GetByUserIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    
    public IQueryable<Model.User> GetAllUserAsync()
    {
        return context.Users.AsQueryable();
    }

    public async Task UpdateUserAsync(Model.User user, CancellationToken cancellationToken = default)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<Model.User?> GetUserByEmailAsync(string email)
    {
        return await context.Users
            .Include(u => u.RoleUsers) // чтобы подгрузить роль
                .ThenInclude(ru => ru.Role)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task DeleteUserAsync(Model.User user, CancellationToken cancellationToken = default)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task MarkNotificationSentAsync(string email)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user != null)
        {
            user.IsSendNotify = true;
            await context.SaveChangesAsync();
        }
    }
}