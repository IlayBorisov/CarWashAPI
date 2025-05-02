using BusinessLogic.Order.Dtos;
using BusinessLogic.Order.Interfaces;
using BusinessLogic.Order.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WashCar.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrderController(IOrderService orderService): ControllerBase
{
    [Authorize(Roles = "Admin,Employee,Customer")]
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var order = await orderService.GetOrderByIdAsync(id, cancellationToken);
            return Ok(order);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Admin,Employee,Customer")]
    [HttpGet]
    public async Task<ActionResult<List<OrderDto>>> GetAll(CancellationToken cancellationToken)
    {
        var orders = await orderService.GetAllOrdersAsync(cancellationToken);
        return Ok(orders);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<OrderDto>> Create([FromBody] OrderCreateRequest orderRequest, CancellationToken cancellationToken)
    {
        var createdOrder = await orderService.CreateOrderAsync(orderRequest, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrderUpdateRequest orderRequest, CancellationToken cancellationToken)
    {
        try
        {
            await orderService.UpdateOrderAsync(id, orderRequest, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("{id:int}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] int newStatus, CancellationToken cancellationToken)
    {
        try
        {
            await orderService.UpdateStatusAsync(id, newStatus, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            await orderService.DeleteOrderAsync(id, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}