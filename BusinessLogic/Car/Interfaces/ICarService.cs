using BusinessLogic.DTO.Car;
using BusinessLogic.DTO.Car.Model;

namespace BusinessLogic.Services.Car;

public interface ICarService
{
    Task<CarDto> GetCarByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<CarDto>> GetAllCarsAsync(CancellationToken cancellationToken);
    Task CreateCarAsync(CarCreateDto  carDto, CancellationToken cancellationToken);
    Task UpdateCarAsync(int id, CarCreateDto  carDto, CancellationToken cancellationToken);
    Task DeleteCarAsync(int id, CancellationToken cancellationToken);
}