using BusinessLogic.Brands.Dtos;
using BusinessLogic.Brands.Interfaces;
using BusinessLogic.Brands.Requests;
using DataAccess.Repositories.Brand;

namespace BusinessLogic.Brands.Services;

public class BrandService(IBrandRepository brandRepository) : IBrandService
{
    public async Task CreateBrandAsync(BrandRequest brandCreate, CancellationToken cancellationToken)
    {
        var brand = new DataAccess.Model.Brand
        {
            Name = brandCreate.Name
        };

        await brandRepository.CreateBrandAsync(brand, cancellationToken);
    }
    
    public async Task<BrandDto> GetBrandByIdAsync(int id, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetBrandByIdAsync(id, cancellationToken);
        if (brand == null)
            throw new Exception("Brand not found");

        return new BrandDto
        {
            Id = brand.Id,
            Name = brand.Name
        };
    }

    public async Task<List<BrandDto>> GetAllBrandsAsync(CancellationToken cancellationToken)
    {
        var brands = await brandRepository.GetAllBrandsAsync(cancellationToken);
        return brands.Select(brand => new BrandDto
        {
            Id = brand.Id,
            Name = brand.Name
        }).ToList();
    }

    public async Task UpdateBrandAsync(int id, BrandRequest brandRequest, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetBrandByIdAsync(id, cancellationToken);
        if (brand == null)
            throw new Exception("Brand not found");

        brand.Name = brandRequest.Name;

        await brandRepository.UpdateBrandAsync(brand, cancellationToken);
    }

    public async Task DeleteBrandAsync(int id, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetBrandByIdAsync(id, cancellationToken);
        if (brand == null)
            throw new Exception("Brand not found");

        await brandRepository.DeleteBrandAsync(brand, cancellationToken);
    }
}