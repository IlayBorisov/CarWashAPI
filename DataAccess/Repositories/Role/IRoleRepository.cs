namespace DataAccess.Repositories.Role;

public interface IRoleRepository
{
    Task<Model.Role> CreateRoleAsync(Model.Role role, CancellationToken cancellationToken = default);
    Task<Model.Role?> GetRoleByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Model.Role>> GetAllRolesAsync(CancellationToken cancellationToken = default);
    Task UpdateRoleAsync(Model.Role role, CancellationToken cancellationToken = default);
    Task DeleteRoleAsync(Model.Role role, CancellationToken cancellationToken = default);
}