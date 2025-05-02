using BusinessLogic.Car.Dtos;
using BusinessLogic.User.Dtos;

namespace BusinessLogic.CustomerCar.Dtos;

public class CustomerCarDto
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Number { get; set; }
    public CarDto Car { get; set; }
    public UserResponse Customer { get; set; }
}