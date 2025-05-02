namespace BusinessLogic.Order.Requests;

public class OrderCreateRequest
{
    public int CustomerCarId { get; set; }
    public int? AdministratorId { get; set; }
    public int EmployeeId { get; set; }
    public List<int> ServiceIds { get; set; } = new();
}