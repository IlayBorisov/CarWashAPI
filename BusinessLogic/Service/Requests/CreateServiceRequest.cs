namespace BusinessLogic.Service.Requests;

public class CreateServiceRequest
{
    public string Name { get; set; } = null!;
    public int PriceRub { get; set; } 
    public int TimeMinutes { get; set; } 
}