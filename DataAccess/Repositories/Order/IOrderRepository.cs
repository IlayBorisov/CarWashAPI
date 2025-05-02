namespace DataAccess.Repositories.Order;

public interface IOrderRepository
{
    Task<Model.Order> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<Model.Order>> GetAllAsync(CancellationToken cancellationToken);
    Task CreateAsync(Model.Order order, CancellationToken cancellationToken);
    Task UpdateAsync(Model.Order order, CancellationToken cancellationToken);
    Task DeleteAsync(Model.Order order, CancellationToken cancellationToken);
}