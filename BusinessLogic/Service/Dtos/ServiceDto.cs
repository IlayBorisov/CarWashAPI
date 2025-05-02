using BusinessLogic.Dtos;

namespace BusinessLogic.Service.Dtos;

public class ServiceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public PriceDto Price { get; set; } = null!;
    public TimeDto Time { get; set; } = null!;
}