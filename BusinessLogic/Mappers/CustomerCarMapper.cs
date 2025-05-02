using BusinessLogic.Brands.Dtos;
using BusinessLogic.DTO.Car.CustomerCar;
using BusinessLogic.DTO.Car.Model;

namespace BusinessLogic.Mappers;

public static class CustomerCarMapper
{
    public static CustomerCarDto ToCustomerCarDto(this DataAccess.Model.CustomerCar customerCar)
    {
        return new CustomerCarDto
        {
            Id = customerCar.Id,
            Year = customerCar.Year,
            Number = customerCar.Number,
            Customer = customerCar.Customer.ToUserResponse(),
            Car = new CarDto
            {
                Model = customerCar.Car.Model,
                Brand = new BrandDto
                {
                    Name = customerCar.Car.Brand.Name
                }
            }
        };
    }
}