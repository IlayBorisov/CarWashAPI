namespace BusinessLogic.DTO.User;

public class UserResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Patronymic { get; set; }
    public string Email { get; set; }
    public bool IsSendNotify { get; set; }
    public string CreatedAt { get; set; }
}