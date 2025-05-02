using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.CustomerCar;

public class CustomerCarRepository(DbContext context) : ICustomerCarRepository
{
    public async Task CreateCustomerCarAsync(Model.CustomerCar customerCar, CancellationToken cancellationToken = default)
    {
        await context.CustomerCars.AddAsync(customerCar, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
    public async Task<Model.CustomerCar?> GetCustomerCarByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.CustomerCars
            .Include(cc => cc.Car)  
            .Include(cc => cc.Customer)
            .FirstOrDefaultAsync(cc => cc.Id == id, cancellationToken);
    }
    
    public async Task<IEnumerable<Model.CustomerCar>> GetAllCarsAsync(CancellationToken cancellationToken = default)
    {
        return await context.CustomerCars
            .Include(cc => cc.Car) 
            .Include(cc => cc.Customer)
            .ToListAsync(cancellationToken);
    }
    
    public async Task UpdateCarAsync(Model.CustomerCar customerCar, CancellationToken cancellationToken = default)
    {
        context.CustomerCars.Update(customerCar);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteCarAsync(Model.CustomerCar customerCar, CancellationToken cancellationToken = default)
    {
        context.CustomerCars.Remove(customerCar);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task LoadCarAndCustomerAsync(Model.CustomerCar customerCar, CancellationToken cancellationToken = default)
    {
        await context.Entry(customerCar).Reference(c => c.Car).LoadAsync(cancellationToken);
        await context.Entry(customerCar).Reference(c => c.Customer).LoadAsync(cancellationToken);
        await context.Entry(customerCar.Car).Reference(c => c.Brand).LoadAsync(cancellationToken);
    }
}