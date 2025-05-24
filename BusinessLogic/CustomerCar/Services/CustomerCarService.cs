using BusinessLogic.Brands.Dtos;
using BusinessLogic.Car.Dtos;
using BusinessLogic.CustomerCar.Dtos;
using BusinessLogic.CustomerCar.Interfaces;
using BusinessLogic.CustomerCar.Requests;
using BusinessLogic.User.Dtos;
using DataAccess.Repositories.CustomerCar;

namespace BusinessLogic.CustomerCar.Services;

public class CustomerCarService(ICustomerCarRepository customerCarRepository) : ICustomerCarService
{
    public async Task<CustomerCarDto> CreateCustomerCarAsync(CustomerCarCreateRequest customerCarRequest, CancellationToken cancellationToken)
    {
        var customerCar = new DataAccess.Model.CustomerCar
        {
            Year = customerCarRequest.Year,
            Number = customerCarRequest.Number,
            CarId = customerCarRequest.CarId,
            CustomerId = customerCarRequest.CustomerId
        };

        await customerCarRepository.CreateCustomerCarAsync(customerCar, cancellationToken);

        // загружаем навигационные свойства (Car и Customer)
        await customerCarRepository.LoadCarAndCustomerAsync(customerCar, cancellationToken);

        return new CustomerCarDto
        {
            Id = customerCar.Id,
            Year = customerCar.Year,
            Number = customerCar.Number,
            Car = new CarDto
            {
                Id = customerCar.Car.Id,
                Model = customerCar.Car.Model,
                Brand = new BrandDto { Id = customerCar.Car.Brand.Id, Name = customerCar.Car.Brand.Name }
            },
            Customer = new UserResponse
            {
                Id = customerCar.Customer.Id,
                FirstName = customerCar.Customer.FirstName,
                LastName = customerCar.Customer.LastName,
            }
        };
    }
    public async Task<CustomerCarDto> GetCustomerCarByIdAsync(int id, CancellationToken cancellationToken)
    {
        var customerCar = await customerCarRepository.GetCustomerCarByIdAsync(id, cancellationToken);
        if (customerCar == null)
            throw new Exception("CustomerCar not found");

        return new CustomerCarDto
        {
            Id = customerCar.Id,
            Year = customerCar.Year,
            Number = customerCar.Number,
            Car = new CarDto { Id = customerCar.Car.Id, Model = customerCar.Car.Model, Brand = new BrandDto { Id = customerCar.Car.Brand.Id, Name = customerCar.Car.Brand.Name } },
            Customer = new UserResponse { Id = customerCar.Customer.Id, FirstName = customerCar.Customer.FirstName, LastName = customerCar.Customer.LastName }
        };
    }
    
    public async Task<List<CustomerCarDto>> GetAllCustomerCarsAsync(CancellationToken cancellationToken)
    {
        var cars = await customerCarRepository.GetAllCarsAsync(cancellationToken);
        return cars.Select(customerCar => new CustomerCarDto
        {
            Id = customerCar.Id,
            Year = customerCar.Year,
            Number = customerCar.Number,
            Car = new CarDto { Id = customerCar.Car.Id, Model = customerCar.Car.Model, Brand = new BrandDto { Id = customerCar.Car.Brand.Id, Name = customerCar.Car.Brand.Name } },
            Customer = new UserResponse { Id = customerCar.Customer.Id, FirstName = customerCar.Customer.FirstName, LastName = customerCar.Customer.LastName }
        }).ToList();
    }

    public async Task UpdateCustomerCarAsync(int id, CustomerCarCreateRequest customerCarRequest, CancellationToken cancellationToken)
    {
        var customerCar = await customerCarRepository.GetCustomerCarByIdAsync(id, cancellationToken);
        if (customerCar == null)
            throw new Exception("CustomerCar not found");

        customerCar.Year = customerCarRequest.Year;
        customerCar.Number = customerCarRequest.Number;
        customerCar.CarId = customerCarRequest.CarId;
        customerCar.CustomerId = customerCarRequest.CustomerId;
        
        await customerCarRepository.UpdateCarAsync(customerCar, cancellationToken);
    }

    public async Task DeleteCustomerCarAsync(int id, CancellationToken cancellationToken)
    {
        var customerCar = await customerCarRepository.GetCustomerCarByIdAsync(id, cancellationToken);
        if (customerCar == null)
            throw new Exception("CustomerCar not found");

        await customerCarRepository.DeleteCarAsync(customerCar, cancellationToken);
    }
}