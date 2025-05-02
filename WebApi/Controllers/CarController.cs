using BusinessLogic.DTO.Car.Model;
using BusinessLogic.Services.Car;
using Microsoft.AspNetCore.Mvc;

namespace WashCar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController(ICarService carService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCarAsync([FromBody] CarCreateDto  carDto, CancellationToken cancellationToken)
    {
        await carService.CreateCarAsync(carDto, cancellationToken);
        return NoContent();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCarAsync(int id, CancellationToken cancellationToken)
    {
        var car = await carService.GetCarByIdAsync(id, cancellationToken);
        return Ok(car);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCars(CancellationToken cancellationToken)
    {
        var cars = await carService.GetAllCarsAsync(cancellationToken);
        return Ok(cars);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCarAsync(int id, [FromBody] CarCreateDto  carDto, CancellationToken cancellationToken)
    {
        await carService.UpdateCarAsync(id, carDto, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCarAsync(int id, CancellationToken cancellationToken)
    {
        await carService.DeleteCarAsync(id, cancellationToken);
        return NoContent();
    }
}
