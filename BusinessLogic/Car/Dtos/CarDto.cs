using BusinessLogic.Brands.Dtos;

namespace BusinessLogic.Car.Dtos;

public class CarDto
{
    public int Id { get; set; }
    public string Model { get; set; }
    public BrandDto Brand { get; set; }
}