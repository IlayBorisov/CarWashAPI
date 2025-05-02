using BusinessLogic.CustomerCar.Dtos;
using BusinessLogic.Service.Dtos;
using BusinessLogic.User.Dtos;

namespace BusinessLogic.Order.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public int Status { get; set; }
    public string StartDate { get; set; } 
    public string EndDate { get; set; } 
    public int TotalTimeMinutes { get; set; }
    public decimal TotalPriceRubles { get; set; }
    public AdministratorDto? Administrator { get; set; }
    public EmployeeDto? Employee { get; set; }
    public CustomerCarDto CustomerCar { get; set; }
    public List<ServiceDto> Services { get; set; } = new();
}