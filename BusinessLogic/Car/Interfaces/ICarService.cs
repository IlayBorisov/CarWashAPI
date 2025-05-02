using BusinessLogic.Car.Dtos;
using BusinessLogic.Car.Requests;

namespace BusinessLogic.Car.Interfaces;

public interface ICarService
{
    Task<CarDto> GetCarByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<CarDto>> GetAllCarsAsync(CancellationToken cancellationToken);
    Task CreateCarAsync(CarCreateRequest  carRequest, CancellationToken cancellationToken);
    Task UpdateCarAsync(int id, CarCreateRequest  carRequest, CancellationToken cancellationToken);
    Task DeleteCarAsync(int id, CancellationToken cancellationToken);
}