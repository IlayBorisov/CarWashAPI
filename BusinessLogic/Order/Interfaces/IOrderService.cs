using BusinessLogic.DTO.Order;
using BusinessLogic.Order.Dtos;
using BusinessLogic.Order.Requests;

namespace BusinessLogic.Order.Interfaces;

public interface IOrderService
{
    Task<OrderDto> GetOrderByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken);
    Task<OrderDto> CreateOrderAsync(OrderCreateDto orderDto, CancellationToken cancellationToken);
    Task UpdateOrderAsync(int id, OrderUpdateDto updateDto, CancellationToken cancellationToken);
    Task DeleteOrderAsync(int id, CancellationToken cancellationToken);
    Task UpdateStatusAsync(int orderId, int newStatus, CancellationToken cancellationToken);
}