namespace BusinessLogic.Order.Requests;

public class OrderUpdateRequest
{
    public int Status { get; set; }
    public int? AdministratorId { get; set; }
    public int? EmployeeId { get; set; }
}