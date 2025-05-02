using BusinessLogic.Dtos;
using BusinessLogic.Service.Dtos;

namespace BusinessLogic.Mappers;

public static class ServiceMapper
{
    public static ServiceDto ToServiceDto(this DataAccess.Model.Service service)
    {
        return new ServiceDto
        {
            Id = service.Id,
            Name = service.Name,
            Price = new PriceDto
            {
                MinValue = service.PriceInCents,
                MaxValue = service.PriceInCents / 100,
                Format = $"{service.PriceInCents / 100} руб."
            },
            Time = new TimeDto
            {
                Seconds = service.TimeInSeconds,
                Minutes = service.TimeInSeconds / 60
            }
        };
    }
}