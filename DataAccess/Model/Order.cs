namespace DataAccess.Model;

public class Order
{
    public int Id { get; set; }
    
    public int Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int CustomersCarId { get; set; }
    public CustomerCar CustomerCar { get; set; } 
    
    public int? AdministratorId { get; set; }
    public User? Administrator { get; set; } 
    
    public int? EmployeeId { get; set; }
    public User? Employee { get; set; } 
    
    public ICollection<OrderService> OrderServices { get; set; } 
}