using BusinessLogic.Role.Dtos;
using BusinessLogic.Role.Interfaces;
using BusinessLogic.Role.Requests;
using DataAccess.Model;
using DataAccess.Repositories.Role;

namespace BusinessLogic.Role.Services;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    public async Task CreateRoleAsync(RoleCreateRequest roleCreateRequest, CancellationToken cancellationToken)
    {
        var role = new DataAccess.Model.Role
        {
            Name = roleCreateRequest.Name,
            RoleUsers = roleCreateRequest.UserId.Select(id => new RoleUser
            {
                UserId = id
            }).ToList()
            
        };
        await roleRepository.CreateRoleAsync(role, cancellationToken);
    }

    public async Task<RoleDto> GetRoleByIdAsync(int id, CancellationToken cancellationToken)
    {
        var role = await roleRepository.GetRoleByIdAsync(id, cancellationToken);
        if (role == null)
            throw new Exception("Role not found");

        return new RoleDto
        {
            Id = role.Id,       
            Name = role.Name
        };
    }
    
    public async Task<List<RoleDto>> GetAllRoleAsync(CancellationToken cancellationToken)
    {
        var roles = await roleRepository.GetAllRolesAsync(cancellationToken);
        return roles.Select(brand => new RoleDto
        {
            Id = brand.Id,
            Name = brand.Name
        }).ToList();
    }

    public async Task UpdateRoleAsync(int id, RoleUpdateRequest roleUpdateRequest, CancellationToken cancellationToken)
    {
        var role = await roleRepository.GetRoleByIdAsync(id, cancellationToken);
        if (role == null)
            throw new Exception("Role not found");

        role.Name = roleUpdateRequest.Name;

        await roleRepository.UpdateRoleAsync(role, cancellationToken);
    }

    public async Task DeleteRoleAsync(int id, CancellationToken cancellationToken)
    {
        var role = await roleRepository.GetRoleByIdAsync(id, cancellationToken);
        if (role == null)
            throw new Exception("Brand not found");

        await roleRepository.DeleteRoleAsync(role, cancellationToken);
    }
    
}