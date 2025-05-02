using BusinessLogic.CustomerCar.Dtos;
using BusinessLogic.CustomerCar.Interfaces;
using BusinessLogic.CustomerCar.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WashCar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerCarController(ICustomerCarService customerCarService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CustomerCarDto>> CreateCustomerCar([FromBody] CustomerCarCreateRequest customerCarRequest, CancellationToken cancellationToken)
    {
        var createdCar = await customerCarService.CreateCustomerCarAsync(customerCarRequest, cancellationToken);
        return Ok(createdCar);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCarAsync(int id, CancellationToken cancellationToken)
    {
        var car = await customerCarService.GetCustomerCarByIdAsync(id, cancellationToken);
        return Ok(car);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCars(CancellationToken cancellationToken)
    {
        var cars = await customerCarService.GetAllCustomerCarsAsync(cancellationToken);
        return Ok(cars);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCarAsync(int id, [FromBody] CustomerCarCreateRequest customerCarRequest,
        CancellationToken cancellationToken)
    {
        await customerCarService.UpdateCustomerCarAsync(id, customerCarRequest, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCarAsync(int id, CancellationToken cancellationToken)
    {
        await customerCarService.DeleteCustomerCarAsync(id, cancellationToken);
        return NoContent();
    }
}