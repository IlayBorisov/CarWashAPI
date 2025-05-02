namespace BusinessLogic.Role.Requests;

public class RoleCreateDto
{
    public string Name { get; set; }
    public List<int> UserId { get; set; }
}