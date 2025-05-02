using BusinessLogic.Brands.Interfaces;
using BusinessLogic.Brands.Services;
using BusinessLogic.Car.Interfaces;
using BusinessLogic.Car.Services;
using BusinessLogic.CustomerCar.Interfaces;
using BusinessLogic.CustomerCar.Services;
using BusinessLogic.Order.Interfaces;
using BusinessLogic.Order.Services;
using BusinessLogic.Role.Interfaces;
using BusinessLogic.Role.Services;
using BusinessLogic.Service.Interfaces;
using BusinessLogic.Service.Services;
using BusinessLogic.User.Interfaces;
using BusinessLogic.User.Services;
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