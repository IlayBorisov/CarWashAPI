namespace BusinessLogic.Dtos;

public class PriceDto
{
    public int MinValue { get; set; } // в копейках
    public int MaxValue { get; set; } // в рублях
    public string Format { get; set; } = null!; // "1 руб"
}