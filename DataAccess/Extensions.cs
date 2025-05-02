using DataAccess.Repositories.Brand;
using DataAccess.Repositories.Car;
using DataAccess.Repositories.CustomerCar;
using DataAccess.Repositories.Order;
using DataAccess.Repositories.Role;
using DataAccess.Repositories.Service;
using DataAccess.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IServiceRepository, ServiceRepository>();
        serviceCollection.AddScoped<ICarRepository, CarRepository>();
        serviceCollection.AddScoped<ICustomerCarRepository, CustomerCarRepository>();
        serviceCollection.AddScoped<IBrandRepository, BrandRepository>();
        serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
        serviceCollection.AddScoped<IRoleRepository, RoleRepository>();
        serviceCollection.AddDbContext<DbContext>(x =>
        {
             x.UseNpgsql("Host=localhost;Port=5438;Database=wash_car_db;Username=wash_car_user;Password=1234");
        });
        return serviceCollection;
    }
}