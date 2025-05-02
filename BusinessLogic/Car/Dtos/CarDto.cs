using BusinessLogic.Brands.Dtos;

namespace BusinessLogic.DTO.Car.Model;

public class CarDto
{
    public int Id { get; set; }
    public string Model { get; set; }
    public BrandDto Brand { get; set; }
}