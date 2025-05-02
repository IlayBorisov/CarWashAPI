using BusinessLogic.Brands.Dtos;
using BusinessLogic.DTO.Car.CustomerCar;
using BusinessLogic.DTO.Car.Model;
using BusinessLogic.DTO.User;
using BusinessLogic.Services.CustomerCar;
using DataAccess.Repositories.CustomerCar;

namespace BusinessLogic.CustomerCar.Services;

public class CustomerCarService(ICustomerCarRepository customerCarRepository) : ICustomerCarService
{
    public async Task<CustomerCarDto> CreateCustomerCarAsync(CustomerCarCreateDto customerCarDto, CancellationToken cancellationToken)
    {
        var customerCar = new DataAccess.Model.CustomerCar
        {
            Year = customerCarDto.Year,
            Number = customerCarDto.Number,
            CarId = customerCarDto.CarId,
            CustomerId = customerCarDto.CustomerId
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
                LastName = customerCar.Customer.LastName
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

    public async Task UpdateCustomerCarAsync(int id, CustomerCarCreateDto customerCarDto, CancellationToken cancellationToken)
    {
        var customerCar = await customerCarRepository.GetCustomerCarByIdAsync(id, cancellationToken);
        if (customerCar == null)
            throw new Exception("CustomerCar not found");

        customerCar.Year = customerCarDto.Year;
        customerCar.Number = customerCarDto.Number;
        
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