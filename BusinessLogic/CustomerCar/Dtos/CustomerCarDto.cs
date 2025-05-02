using BusinessLogic.DTO.Car.Model;
using BusinessLogic.DTO.User;
 
namespace BusinessLogic.DTO.Car.CustomerCar;

public class CustomerCarDto
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Number { get; set; }
    public CarDto Car { get; set; }
    public UserResponse Customer { get; set; }
}