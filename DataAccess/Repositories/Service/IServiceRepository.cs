namespace DataAccess.Repositories.Service;

public interface IServiceRepository
{
    Task<Model.Service> CreateServiceAsync(Model.Service service, CancellationToken cancellationToken = default);
    Task<Model.Service?> GetByServiceIdAsync(int ids, CancellationToken cancellationToken = default);
    Task<List<Model.Service>> GetByServiceIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    Task<List<Model.Service>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateServiceAsync(Model.Service service, CancellationToken cancellationToken = default);
    Task DeleteServiceAsync(Model.Service service, CancellationToken cancellationToken = default);
}