namespace BusinessLogic.Order.Requests;

public class AddServicesRequest
{
    public int OrderId { get; set; }
    public List<int> ServiceIds { get; set; } = new();
}