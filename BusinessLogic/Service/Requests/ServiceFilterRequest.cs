namespace BusinessLogic.Service.Requests;

public class ServiceFilterRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; }
    public bool Ascending { get; set; } = true;
    public int? MinPriceRub { get; set; }
    public int? MaxPriceRub { get; set; }
}