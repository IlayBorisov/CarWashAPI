using BusinessLogic.Mappers;
using BusinessLogic.Order.Dtos;
using BusinessLogic.Order.Interfaces;
using BusinessLogic.Order.Requests;
using DataAccess.Repositories.Order;
using DataAccess.Repositories.Service;

namespace BusinessLogic.Order.Services;

public class OrderService(IOrderRepository orderRepository, IServiceRepository serviceRepository) : IOrderService
{
    public async Task<OrderDto> GetOrderByIdAsync(int id, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(id, cancellationToken);
        if (order == null)
            throw new Exception("Order not found");

        return order.ToOrderDto();
    }

    public async Task<List<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetAllAsync(cancellationToken);
        return orders.Select(o => o.ToOrderDto()).ToList();
    }

    public async Task<OrderDto> CreateOrderAsync(OrderCreateRequest orderRequest, CancellationToken cancellationToken)
    {
        var order = new DataAccess.Model.Order
        {
            CustomersCarId = orderRequest.CustomerCarId,
            AdministratorId = orderRequest.AdministratorId,
            EmployeeId = orderRequest.EmployeeId,
            StartDate = DateTime.UtcNow,
            OrderServices = orderRequest.ServiceIds.Select(id => new DataAccess.Model.OrderService
            {
                ServiceId = id
            }).ToList()
        };
            
        // загружаем сервисы по id, чтобы получить их время
        var services = await serviceRepository.GetByServiceIdsAsync(orderRequest.ServiceIds, cancellationToken);
        var totalSeconds = services.Sum(s => s.TimeInSeconds);
        order.EndDate = order.StartDate.AddSeconds(totalSeconds);

        await orderRepository.CreateAsync(order, cancellationToken);

        var createdOrder = await orderRepository.GetByIdAsync(order.Id, cancellationToken);

        return createdOrder.ToOrderDto();
    }

    public async Task UpdateOrderAsync(int id, OrderUpdateRequest updateRequest, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(id, cancellationToken);
        if (order == null)
            throw new Exception("Order not found");

        order.Status = updateRequest.Status;
        order.AdministratorId = updateRequest.AdministratorId;
        order.EmployeeId = updateRequest.EmployeeId;

        await orderRepository.UpdateAsync(order, cancellationToken);
    }

    public async Task DeleteOrderAsync(int id, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(id, cancellationToken);
        if (order == null)
            throw new Exception("Order not found");

        await orderRepository.DeleteAsync(order, cancellationToken);
    }
    
    public async Task UpdateStatusAsync(int orderId, int newStatus, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(orderId, cancellationToken);
        if (order == null)
            throw new Exception($"Заказ с id {orderId} не найден");

        order.Status = newStatus;
        await orderRepository.UpdateAsync(order, cancellationToken);
    }
}