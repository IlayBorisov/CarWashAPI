namespace BusinessLogic.User.Requests;

public class UserServiceRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}