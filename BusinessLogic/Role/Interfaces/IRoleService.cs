using BusinessLogic.Role.Dtos;
using BusinessLogic.Role.Requests;

namespace BusinessLogic.Role.Interfaces;

public interface IRoleService
{
    Task CreateRoleAsync(RoleCreateDto roleCreateDto, CancellationToken cancellationToken);
    Task<RoleDto> GetRoleByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<RoleDto>> GetAllRoleAsync(CancellationToken cancellationToken);
    Task UpdateRoleAsync(int id, RoleUpdateDto roleUpdateDto, CancellationToken cancellationToken);
    Task DeleteRoleAsync(int id, CancellationToken cancellationToken);
}