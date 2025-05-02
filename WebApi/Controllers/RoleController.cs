using BusinessLogic.Role.Interfaces;
using BusinessLogic.Role.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WashCar.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RoleController(IRoleService roleService) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateRoleAsync([FromBody] RoleCreateRequest roleCreateRequest,
        CancellationToken cancellationToken)
    {
        await roleService.CreateRoleAsync(roleCreateRequest, cancellationToken);
        return NoContent();
    }
    
    [Authorize(Roles = "Admin,Employee,Customer")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetRoleAsync(int id, CancellationToken cancellationToken)
    {
        var role = await roleService.GetRoleByIdAsync(id, cancellationToken);
        return Ok(role);
    }

    [Authorize(Roles = "Admin,Employee,Customer")]
    [HttpGet]
    public async Task<IActionResult> GetAllRoleAsync(CancellationToken cancellationToken)
    {
        var role = await roleService.GetAllRoleAsync(cancellationToken);
        return Ok(role);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateRoleAsync(int id, [FromBody] RoleUpdateRequest role,
        CancellationToken cancellationToken)
    {
        await roleService.UpdateRoleAsync(id, role, cancellationToken);
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteRoleAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        await roleService.DeleteRoleAsync(id, cancellationToken);
        return NoContent();
    }
}