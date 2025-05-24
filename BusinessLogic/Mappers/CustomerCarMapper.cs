using BusinessLogic.Brands.Dtos;
using BusinessLogic.Car.Dtos;
using BusinessLogic.CustomerCar.Dtos;

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
            Car = customerCar.Car == null ? null : new CarDto
            {
                Id = customerCar.Car.Id,
                Model = customerCar.Car.Model,
                Brand = customerCar.Car.Brand == null ? null :new BrandDto
                {
                    Id = customerCar.Car.Brand.Id,
                    Name = customerCar.Car.Brand.Name
                }
            }
        };
    }
}