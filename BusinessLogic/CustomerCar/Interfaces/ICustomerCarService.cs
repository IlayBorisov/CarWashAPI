using BusinessLogic.CustomerCar.Dtos;
using BusinessLogic.CustomerCar.Requests;

namespace BusinessLogic.CustomerCar.Interfaces;

public interface ICustomerCarService
{
    Task<CustomerCarDto> CreateCustomerCarAsync(CustomerCarCreateRequest customerCarRequest, CancellationToken cancellationToken);
    Task<CustomerCarDto> GetCustomerCarByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<CustomerCarDto>> GetAllCustomerCarsAsync(CancellationToken cancellationToken);
    Task UpdateCustomerCarAsync(int id, CustomerCarCreateRequest customerCarRequest, CancellationToken cancellationToken);
    Task DeleteCustomerCarAsync(int id, CancellationToken cancellationToken);
}