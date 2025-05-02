using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Service;

public class ServiceRepository(DbContext context) : IServiceRepository
{
    public async Task<Model.Service> CreateServiceAsync(Model.Service service, CancellationToken cancellationToken = default)
    {
        await context.Services.AddAsync(service, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return service;
    }

    public async Task<Model.Service?> GetByServiceIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Services.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    
    public async Task<List<Model.Service>> GetByServiceIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
    {
        return await context.Services.Where(s => ids.Contains(s.Id)).ToListAsync(cancellationToken);
    }
    
    public async Task<List<Model.Service>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Services.ToListAsync(cancellationToken);
    }
    
    public async Task UpdateServiceAsync(Model.Service service, CancellationToken cancellationToken = default)
    {
        context.Services.Update(service);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteServiceAsync(Model.Service service, CancellationToken cancellationToken = default)
    {
        context.Services.Remove(service);
        await context.SaveChangesAsync(cancellationToken);
    }
}