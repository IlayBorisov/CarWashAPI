namespace DataAccess.Repositories.CustomerCar;

public interface ICustomerCarRepository
{
    Task CreateCustomerCarAsync(Model.CustomerCar customerCar, CancellationToken cancellationToken);
    Task<Model.CustomerCar?> GetCustomerCarByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Model.CustomerCar>> GetAllCarsAsync(CancellationToken cancellationToken = default);
    Task UpdateCarAsync(Model.CustomerCar customerCar, CancellationToken cancellationToken = default);
    Task DeleteCarAsync(Model.CustomerCar customerCar, CancellationToken cancellationToken = default);
    Task LoadCarAndCustomerAsync(Model.CustomerCar customerCar, CancellationToken cancellationToken = default);
}