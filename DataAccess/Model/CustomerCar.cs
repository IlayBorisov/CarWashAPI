namespace DataAccess.Model;

public class CustomerCar
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Number { get; set; }
    
    public int CarId { get; set; }
    public Car Car { get; set; } 
    
    public int CustomerId { get; set; }
    public User Customer { get; set; } 
    
    public ICollection<Order> Orders { get; set; }
}