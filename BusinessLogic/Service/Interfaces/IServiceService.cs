using BusinessLogic.Service.Dtos;
using BusinessLogic.Service.Requests;

namespace BusinessLogic.Service.Interfaces;

public interface IServiceService
{
    Task<ServiceDto> CreateAsync(CreateServiceRequest request, CancellationToken cancellationToken = default);
    Task<ServiceDto> GetByServiceIdAsync(int id, CancellationToken cancellationToken = default);

    Task<List<ServiceDto>> GetAllAsync(string? sortBy = null, bool ascending = true, int page = 1,
        int pageSize = 10, CancellationToken cancellationToken = default);

    Task UpdateAsync(int id, CreateServiceRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}