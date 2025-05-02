namespace DataAccess.Model;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public int PriceInCents { get; set; }
    public int TimeInSeconds { get; set; }
    
    public ICollection<OrderService> OrderServices { get; set; } 
}