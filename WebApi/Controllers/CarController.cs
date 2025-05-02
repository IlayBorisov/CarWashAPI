using BusinessLogic.Car.Interfaces;
using BusinessLogic.Car.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WashCar.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CarController(ICarService carService) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateCarAsync([FromBody] CarCreateRequest  carRequest, CancellationToken cancellationToken)
    {
        await carService.CreateCarAsync(carRequest, cancellationToken);
        return NoContent();
    }

    [Authorize(Roles = "Admin,Employee,Customer")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCarAsync(int id, CancellationToken cancellationToken)
    {
        var car = await carService.GetCarByIdAsync(id, cancellationToken);
        return Ok(car);
    }
    
    [Authorize(Roles = "Admin,Employee,Customer")]
    [HttpGet]
    public async Task<IActionResult> GetAllCars(CancellationToken cancellationToken)
    {
        var cars = await carService.GetAllCarsAsync(cancellationToken);
        return Ok(cars);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCarAsync(int id, [FromBody] CarCreateRequest  carRequest, CancellationToken cancellationToken)
    {
        await carService.UpdateCarAsync(id, carRequest, cancellationToken);
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCarAsync(int id, CancellationToken cancellationToken)
    {
        await carService.DeleteCarAsync(id, cancellationToken);
        return NoContent();
    }
}
