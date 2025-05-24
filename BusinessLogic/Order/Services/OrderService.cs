using BusinessLogic.Email.Service;
using BusinessLogic.Mappers;
using BusinessLogic.Order.Dtos;
using BusinessLogic.Order.Interfaces;
using BusinessLogic.Order.Requests;
using DataAccess.Repositories.CustomerCar;
using DataAccess.Repositories.Order;
using DataAccess.Repositories.Service;

namespace BusinessLogic.Order.Services;

public class OrderService(IOrderRepository orderRepository, IServiceRepository serviceRepository, ICustomerCarRepository customerCarRepository, EmailService emailService) : IOrderService
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
        var customerCar = await customerCarRepository.GetCustomerCarByIdAsync(orderRequest.CustomerCarId, cancellationToken);
        if (customerCar == null)
            throw new Exception("Customer car not found");
        
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

        if (customerCar.Customer?.IsSendNotify == true && 
            !string.IsNullOrEmpty(customerCar.Customer.Email))
        {
            var emailBody = $"""
                             <h1>Ваш заказ #{order.Id}</h1>
                             <p>Дата: {order.StartDate:dd.MM.yyyy HH:mm}</p>
                             <p>Автомобиль: {customerCar.Car?.Model}</p>
                             <p>Услуги: {string.Join(", ", services.Select(s => s.Name))}</p>
                             """;

            await emailService.SendEmailAsync(
                customerCar.Customer.Email,
                $"Новый заказ #{order.Id}",
                emailBody);
        }
        
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
        
        var oldStatus = order.Status;
        order.Status = newStatus;
        
        if (newStatus == 1 && oldStatus != 1 && 
            order.CustomerCar?.Customer?.IsSendNotify == true)
        {
            var emailBody = $"""
                             <h1>Ваш заказ #{order.Id} готов!</h1>
                             <p>Дата готовности: {DateTime.Now:dd.MM.yyyy HH:mm}</p>
                             <p>Автомобиль: {order.CustomerCar.Car?.Model}</p>
                             """;
            
            await emailService.SendEmailAsync(
                order.CustomerCar.Customer.Email,
                $"Заказ #{order.Id} готов",
                emailBody);
        }
        await orderRepository.UpdateAsync(order, cancellationToken);
    }
    
    public async Task AddServicesToOrderAsync(AddServicesRequest request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(request.OrderId, cancellationToken);
        if (order == null)
            throw new Exception("Order not found");
        
        var services = await serviceRepository.GetByServiceIdsAsync(request.ServiceIds, cancellationToken);
        if (!services.Any())
            throw new Exception("No valid services provided");
        
        foreach (var serviceId in request.ServiceIds)
        {
            if (!order.OrderServices.Any(os => os.ServiceId == serviceId) && order.Status != 1)
            {
                order.OrderServices.Add(new DataAccess.Model.OrderService
                {
                    ServiceId = serviceId,
                    OrderId = request.OrderId
                });
            }
        }
        
        var allServices = await serviceRepository.GetByServiceIdsAsync(
            order.OrderServices.Select(os => os.ServiceId).ToList(), 
            cancellationToken);
    
        order.EndDate = order.StartDate.AddSeconds(allServices.Sum(s => s.TimeInSeconds));
        await orderRepository.UpdateAsync(order, cancellationToken);
    }
}