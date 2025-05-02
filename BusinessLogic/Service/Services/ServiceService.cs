using BusinessLogic.Dtos;
using BusinessLogic.Service.Dtos;
using BusinessLogic.Service.Interfaces;
using BusinessLogic.Service.Requests;
using DataAccess.Repositories.Service;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<PaginatedResponse<ServiceDto>> GetAllAsync(ServiceFilterRequest request, CancellationToken cancellationToken = default)
    {
        var query = serviceRepository.GetAll();
        
        if (request.MinPriceRub.HasValue)
        {
            query = query.Where(s => s.PriceInCents >= request.MinPriceRub * 100);
        }
        if (request.MaxPriceRub.HasValue)
        {
            query = query.Where(s => s.PriceInCents <= request.MaxPriceRub * 100);
        }

        query = request.SortBy?.ToLower() switch
        {
            "price" => request.Ascending
                ? query.OrderBy(x => x.PriceInCents)
                : query.OrderByDescending(x => x.PriceInCents),
            "time" => request.Ascending
                ? query.OrderBy(x => x.TimeInSeconds)
                : query.OrderByDescending(x => x.TimeInSeconds),
            _ => query.OrderBy(x => x.Id)
        };
        
        var totalCount = await query.CountAsync(cancellationToken); // подсчет без пагинации

        // а тут уже пагинация
        var items = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(service => new ServiceDto
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
            })
            .ToListAsync(cancellationToken);

        return new PaginatedResponse<ServiceDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
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