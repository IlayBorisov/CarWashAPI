using BusinessLogic.Service.Dtos;
using BusinessLogic.Service.Requests;
using BusinessLogic.Service.Services;

namespace BusinessLogic.Service.Interfaces;

public interface IServiceService
{
    Task<ServiceDto> CreateAsync(CreateServiceRequest request, CancellationToken cancellationToken = default);
    Task<ServiceDto> GetByServiceIdAsync(int id, CancellationToken cancellationToken = default);

    Task<PaginatedResponse<ServiceDto>> GetAllAsync(ServiceFilterRequest request, CancellationToken cancellationToken = default);

    Task UpdateAsync(int id, CreateServiceRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}