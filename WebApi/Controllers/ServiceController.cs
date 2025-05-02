using BusinessLogic.Service.Requests;
using BusinessLogic.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace WashCar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController(IServiceService serviceService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceRequest request, CancellationToken cancellationToken)
    {
        var service = await serviceService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = service.Id }, service);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var service = await serviceService.GetByServiceIdAsync(id, cancellationToken);
        return Ok(service);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? sortBy, [FromQuery] bool ascending = true,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var services = await serviceService.GetAllAsync(sortBy, ascending, page, pageSize, cancellationToken);
        return Ok(services);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, CreateServiceRequest request, CancellationToken cancellationToken)
    {
        await serviceService.UpdateAsync(id, request, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await serviceService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}