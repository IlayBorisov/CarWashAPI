using BusinessLogic.Role.Interfaces;
using BusinessLogic.Role.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WashCar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController(IRoleService roleService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRoleAsync([FromBody] RoleCreateDto roleCreateDto,
        CancellationToken cancellationToken)
    {
        await roleService.CreateRoleAsync(roleCreateDto, cancellationToken);
        return NoContent();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetRoleAsync(int id, CancellationToken cancellationToken)
    {
        var role = await roleService.GetRoleByIdAsync(id, cancellationToken);
        return Ok(role);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoleAsync(CancellationToken cancellationToken)
    {
        var role = await roleService.GetAllRoleAsync(cancellationToken);
        return Ok(role);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateRoleAsync(int id, [FromBody] RoleUpdateDto role,
        CancellationToken cancellationToken)
    {
        await roleService.UpdateRoleAsync(id, role, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteRoleAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        await roleService.DeleteRoleAsync(id, cancellationToken);
        return NoContent();
    }
}