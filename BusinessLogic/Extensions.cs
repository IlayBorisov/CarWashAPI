using BusinessLogic.Car.Services;
using BusinessLogic.CustomerCar.Services;
using BusinessLogic.DTO.Car;
using BusinessLogic.Order.Interfaces;
using BusinessLogic.Order.Services;
using BusinessLogic.Role.Interfaces;
using BusinessLogic.Role.Services;
using BusinessLogic.Service.Services;
using BusinessLogic.Services.Brand;
using BusinessLogic.Services.Car;
using BusinessLogic.Services.CustomerCar;
using BusinessLogic.Services.Service;
using BusinessLogic.Services.User;
using DataAccess;
using DataAccess.Repositories.Role;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic;

public static class Extensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IServiceService, ServiceService>();
        serviceCollection.AddScoped<ICarService, CarService>();
        serviceCollection.AddScoped<ICustomerCarService, CustomerCarService>();
        serviceCollection.AddScoped<IBrandService, BrandService>();
        serviceCollection.AddScoped<IOrderService, OrderService>();
        serviceCollection.AddScoped<IRoleService, RoleService>();
        return serviceCollection;
    }
}