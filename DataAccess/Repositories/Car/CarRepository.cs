using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Car;

public class CarRepository(DbContext context) : ICarRepository
{
    public async Task<Model.Car> CreateCarAsync(Model.Car car, CancellationToken cancellationToken = default)
    {
        await context.Cars.AddAsync(car, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return car;
    }
    
    public async Task<Model.Car?> GetCarByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Cars
            .Include(c => c.Brand)  
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
    
    public async Task<IEnumerable<Model.Car>> GetAllCarsAsync(CancellationToken cancellationToken = default)
    {
        return await context.Cars
            .Include(c => c.Brand)  
            .ToListAsync(cancellationToken);
    }
    
    public async Task UpdateCarAsync(Model.Car car, CancellationToken cancellationToken = default)
    {
        context.Cars.Update(car);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteCarAsync(Model.Car car, CancellationToken cancellationToken = default)
    {
        context.Cars.Remove(car);
        await context.SaveChangesAsync(cancellationToken);
    }
}