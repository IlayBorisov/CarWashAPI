using BusinessLogic.Service.Interfaces;
using BusinessLogic.Service.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WashCar.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ServiceController(IServiceService serviceService) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceRequest request, CancellationToken cancellationToken)
    {
        var service = await serviceService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = service.Id }, service);
    }
    
    [Authorize(Roles = "Admin,Employee,Customer")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var service = await serviceService.GetByServiceIdAsync(id, cancellationToken);
        return Ok(service);
    }
    
    [Authorize(Roles = "Admin,Employee,Customer")]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ServiceFilterRequest request, CancellationToken cancellationToken = default)
    {
        var services = await serviceService.GetAllAsync(request, cancellationToken);
        return Ok(services);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, CreateServiceRequest request, CancellationToken cancellationToken)
    {
        await serviceService.UpdateAsync(id, request, cancellationToken);
        return NoContent();
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await serviceService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}