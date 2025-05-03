using BusinessLogic.User.Interfaces;
using BusinessLogic.User.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WashCar.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController(IUserService userService) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest request)
    {
        await userService.CreateUserAsync(request);
        return NoContent();
    }
    
    [Authorize(Roles = "Admin,Employee,Customer")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserAsync([FromRoute] int id)
    {
        var result = await userService.GetByUserIdAsync(id);
        return Ok(result);
    }
    
    [Authorize(Roles = "Admin,Employee,Customer")]
    [HttpGet]
    public async Task<IActionResult> GetAllUserAsync([FromQuery] UserServiceRequest request)
    {
        var result = await userService.GetAllAsync(request);
        return Ok(result);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateUserAsync([FromRoute] int id, [FromBody] CreateUserRequest request)
    {
        await userService.UpdateUserAsync(id, request);
        return NoContent();
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUserAsync([FromRoute] int id)
    {
        await userService.DeleteUserAsync(id);
        return NoContent();
    }
}