namespace DataAccess.Repositories.Car;

public interface ICarRepository
{
    Task<Model.Car> CreateCarAsync(Model.Car car, CancellationToken cancellationToken = default);
    Task<Model.Car?> GetCarByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Model.Car>> GetAllCarsAsync(CancellationToken cancellationToken = default);
    Task UpdateCarAsync(Model.Car car, CancellationToken cancellationToken = default);
    Task DeleteCarAsync(Model.Car car, CancellationToken cancellationToken = default);
}