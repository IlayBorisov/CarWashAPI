using BusinessLogic.Dtos;
using BusinessLogic.Service.Dtos;
using BusinessLogic.Service.Requests;
using BusinessLogic.Services.Service;
using DataAccess.Repositories.Service;

namespace BusinessLogic.Service.Services;

public class ServiceService(IServiceRepository serviceRepository) : IServiceService
{
    public async Task<ServiceDto> CreateAsync(CreateServiceRequest request, CancellationToken cancellationToken = default)
    {
        var service = new DataAccess.Model.Service()
        {
            Name = request.Name,
            PriceInCents = request.PriceRub * 100,
            TimeInSeconds = request.TimeMinutes * 60
        };
         var created = await serviceRepository.CreateServiceAsync(service, cancellationToken);
         return ToDto(created);
    }
    
    public async Task<ServiceDto> GetByServiceIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var service = await serviceRepository.GetByServiceIdAsync(id, cancellationToken)
                      ?? throw new Exception("Service not found");

        return ToDto(service);
    }
    
    public async Task<List<ServiceDto>> GetAllAsync(string? sortBy = null, bool ascending = true, int page = 1,
        int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var services = await serviceRepository.GetAllAsync(cancellationToken);

        var query = services.AsQueryable();
        
        if (sortBy == "price")
            query = ascending ? query.OrderBy(x => x.PriceInCents) : query.OrderByDescending(x => x.PriceInCents);
        else if (sortBy == "time")
            query = ascending ? query.OrderBy(x => x.TimeInSeconds) : query.OrderByDescending(x => x.TimeInSeconds);
        
        query = query.Skip((page - 1) * pageSize).Take(pageSize);

        return query.Select(ToDto).ToList();
    }
    
    public async Task UpdateAsync(int id, CreateServiceRequest request, CancellationToken cancellationToken = default)
    {
        var service = await serviceRepository.GetByServiceIdAsync(id, cancellationToken)
                      ?? throw new Exception("Service not found");

        service.Name = request.Name;
        service.PriceInCents = request.PriceRub * 100;
        service.TimeInSeconds = request.TimeMinutes * 60;

        await serviceRepository.UpdateServiceAsync(service, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var service = await serviceRepository.GetByServiceIdAsync(id, cancellationToken)
                      ?? throw new Exception("Service not found");

        await serviceRepository.DeleteServiceAsync(service, cancellationToken);
    }
    
    private static ServiceDto ToDto(DataAccess.Model.Service service)
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