namespace DataAccess.Model;

public class User
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Patronymic { get; set; }
    public required string Email { get; set; }
    public bool IsSendNotify { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public ICollection<RoleUser> RoleUsers { get; set; } 
    public ICollection<Order> OrdersAsAdministrator { get; set; }
    public ICollection<Order> OrdersAsEmployee { get; set; } 
    public ICollection<CustomerCar> CustomerCars { get; set; }
}