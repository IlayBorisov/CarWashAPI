namespace DataAccess.Model;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Car> Cars { get; set; }
}