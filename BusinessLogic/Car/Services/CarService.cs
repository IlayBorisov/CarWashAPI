using BusinessLogic.Brands.Dtos;
using BusinessLogic.DTO.Car.Model;
using BusinessLogic.Services.Car;
using DataAccess.Repositories.Car;

namespace BusinessLogic.Car.Services;

public class CarService(ICarRepository carRepository) : ICarService
{
    public async Task CreateCarAsync(CarCreateDto carDto, CancellationToken cancellationToken)
    {
        var car = new DataAccess.Model.Car
        {
            Model = carDto.Model,
            BrandId = carDto.BrandId
        };

        await carRepository.CreateCarAsync(car, cancellationToken);
    }
    
    public async Task<CarDto> GetCarByIdAsync(int id, CancellationToken cancellationToken)
    {
        var car = await carRepository.GetCarByIdAsync(id, cancellationToken);
        if (car == null)
            throw new Exception("Car not found");

        return new CarDto
        {
            Id = car.Id,
            Model = car.Model,
            Brand = new BrandDto { Id = car.Brand.Id, Name = car.Brand.Name }
        };
    }

    public async Task<List<CarDto>> GetAllCarsAsync(CancellationToken cancellationToken)
    {
        var cars = await carRepository.GetAllCarsAsync(cancellationToken);
        return cars.Select(car => new CarDto
        {
            Id = car.Id,
            Model = car.Model,
            Brand = new BrandDto { Id = car.Brand.Id, Name = car.Brand.Name }
        }).ToList();
    }

    public async Task UpdateCarAsync(int id, CarCreateDto  carDto, CancellationToken cancellationToken)
    {
        var car = await carRepository.GetCarByIdAsync(id, cancellationToken);
        if (car == null)
            throw new Exception("Car not found");

        car.Model = carDto.Model;

        await carRepository.UpdateCarAsync(car, cancellationToken);
    }

    public async Task DeleteCarAsync(int id, CancellationToken cancellationToken)
    {
        var car = await carRepository.GetCarByIdAsync(id, cancellationToken);
        if (car == null)
            throw new Exception("Car not found");

        await carRepository.DeleteCarAsync(car, cancellationToken);
    }
}