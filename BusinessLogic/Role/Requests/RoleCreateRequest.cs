namespace BusinessLogic.Role.Requests;

public class RoleCreateRequest
{
    public string Name { get; set; }
    public List<int> UserId { get; set; }
}