namespace DataAccess.Model;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<RoleUser> RoleUsers { get; set; } 
}