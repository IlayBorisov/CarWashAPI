using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Order;

public class OrderRepository(DbContext context) : IOrderRepository
{
    public async Task<Model.Order> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Orders
            .Include(o => o.OrderServices)
                .ThenInclude(os => os.Service)
            .Include(o => o.CustomerCar)
                .ThenInclude(cc => cc.Customer)
            .Include(o => o.CustomerCar)
                .ThenInclude(cc => cc.Car)
                    .ThenInclude(c => c.Brand)
            .Include(o => o.Administrator)
            .Include(o => o.Employee)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<List<Model.Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Orders
            .Include(o => o.OrderServices).ThenInclude(os => os.Service)
            .Include(o => o.CustomerCar).ThenInclude(cc => cc.Customer)
            .Include(o => o.CustomerCar).ThenInclude(cc => cc.Car)
            .Include(o => o.Administrator)
            .Include(o => o.Employee)
            .ToListAsync(cancellationToken);
    }

    public async Task CreateAsync(Model.Order order, CancellationToken cancellationToken)
    {
        await context.Orders.AddAsync(order, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Model.Order order, CancellationToken cancellationToken)
    {
        context.Orders.Update(order);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Model.Order order, CancellationToken cancellationToken)
    {
        context.Orders.Remove(order);
        await context.SaveChangesAsync(cancellationToken);
    }
}