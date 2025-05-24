using BusinessLogic.Order.Dtos;
using BusinessLogic.Order.Requests;

namespace BusinessLogic.Order.Interfaces;

public interface IOrderService
{
    Task<OrderDto> GetOrderByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken);
    Task<OrderDto> CreateOrderAsync(OrderCreateRequest orderRequest, CancellationToken cancellationToken);
    Task UpdateOrderAsync(int id, OrderUpdateRequest updateRequest, CancellationToken cancellationToken);
    Task DeleteOrderAsync(int id, CancellationToken cancellationToken);
    Task UpdateStatusAsync(int orderId, int newStatus, CancellationToken cancellationToken);
    Task AddServicesToOrderAsync(AddServicesRequest request, CancellationToken cancellationToken);
}