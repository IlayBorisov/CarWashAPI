namespace DataAccess.Model;

public class Car
{
    public int Id { get; set; }
    public string Model { get; set; }
    
    public int BrandId { get; set; }
    public Brand Brand { get; set; } 
    
    public ICollection<CustomerCar> CustomerCars { get; set; } 
}