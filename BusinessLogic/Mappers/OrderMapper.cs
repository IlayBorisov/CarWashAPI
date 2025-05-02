using BusinessLogic.DTO.Order;
using BusinessLogic.DTO.User;
using BusinessLogic.Order.Dtos;
using DataAccess.Model;

namespace BusinessLogic.Mappers;

public static class OrderMapper
{
    public static OrderDto ToOrderDto(this DataAccess.Model.Order order)
    {
        var totalSeconds = order.OrderServices.Sum(os => os.Service.TimeInSeconds);
        var totalPrice = order.OrderServices.Sum(os => os.Service.PriceInCents) / 100m;

        return new OrderDto
        {
            Id = order.Id,
            Status = order.Status,
            StartDate = order.StartDate.ToString("dd.MM.yyyy HH:mm"),
            EndDate = order.EndDate.ToString("dd.MM.yyyy HH:mm"),
            TotalTimeMinutes = totalSeconds / 60,
            TotalPriceRubles = totalPrice,
            Administrator = order.Administrator == null ? null : new AdministratorDto
            {
                Id = order.Administrator.Id,
                FullName = $"{order.Administrator.LastName} {order.Administrator.FirstName} {order.Administrator.Patronymic}"
            },
            Employee = order.Employee == null ? null : new EmployeeDto
            {
                Id = order.Employee.Id,
                FullName = $"{order.Employee.LastName} {order.Employee.FirstName} {order.Employee.Patronymic}"
            },
            CustomerCar = order.CustomerCar.ToCustomerCarDto(),
            Services = order.OrderServices.Select(os => os.Service.ToServiceDto()).ToList()
        };
    }

    public static UserResponse ToUserResponse(this User user) => new UserResponse
    {
        Id = user.Id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Patronymic = user.Patronymic,
        Email = user.Email,
        IsSendNotify = user.IsSendNotify,
        CreatedAt = user.CreatedAt.ToString("dd.MM.yyyy HH:mm")
    };
}