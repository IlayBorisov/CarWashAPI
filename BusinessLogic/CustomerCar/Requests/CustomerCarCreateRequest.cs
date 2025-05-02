namespace BusinessLogic.CustomerCar.Requests;

public class CustomerCarCreateRequest
{
    public int Year { get; set; }
    public string Number { get; set; } = string.Empty;
    public int CarId { get; set; } 
    public int CustomerId { get; set; } 
}