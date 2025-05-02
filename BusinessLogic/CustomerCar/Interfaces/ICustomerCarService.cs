using BusinessLogic.DTO.Car;
using BusinessLogic.DTO.Car.CustomerCar;

namespace BusinessLogic.Services.CustomerCar;

public interface ICustomerCarService
{
    Task<CustomerCarDto> CreateCustomerCarAsync(CustomerCarCreateDto customerCarDto, CancellationToken cancellationToken);
    Task<CustomerCarDto> GetCustomerCarByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<CustomerCarDto>> GetAllCustomerCarsAsync(CancellationToken cancellationToken);
    Task UpdateCustomerCarAsync(int id, CustomerCarCreateDto customerCarDto, CancellationToken cancellationToken);
    Task DeleteCustomerCarAsync(int id, CancellationToken cancellationToken);
}