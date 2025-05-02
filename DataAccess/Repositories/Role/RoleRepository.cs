using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Role;

public class RoleRepository(DbContext context) : IRoleRepository
{
    public async Task<Model.Role> CreateRoleAsync(Model.Role role, CancellationToken cancellationToken = default)
    {
        await context.Roles.AddAsync(role, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return role;
    }
    
    public async Task<Model.Role?> GetRoleByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Roles
            .Include(r => r.RoleUsers).ThenInclude(ru => ru.User)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }
    
    public async Task<IEnumerable<Model.Role>> GetAllRolesAsync(CancellationToken cancellationToken = default)
    {
        return await context.Roles
            .Include(r => r.RoleUsers).ThenInclude(ru => ru.User)
            .ToListAsync(cancellationToken);
    }
    
    public async Task UpdateRoleAsync(Model.Role role, CancellationToken cancellationToken = default)
    {
        context.Roles.Update(role);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRoleAsync(Model.Role role, CancellationToken cancellationToken = default)
    {
        context.Roles.Remove(role);
        await context.SaveChangesAsync(cancellationToken);
    }
}