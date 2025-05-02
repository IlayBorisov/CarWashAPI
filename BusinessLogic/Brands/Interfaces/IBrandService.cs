using BusinessLogic.Brands.Dtos;
using BusinessLogic.Brands.Requests;

namespace BusinessLogic.Brands.Interfaces;

public interface IBrandService
{
    Task CreateBrandAsync(BrandRequest brandCreate, CancellationToken cancellationToken);
    Task<BrandDto> GetBrandByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<BrandDto>> GetAllBrandsAsync(CancellationToken cancellationToken);
    Task UpdateBrandAsync(int id, BrandRequest brandRequest, CancellationToken cancellationToken);
    Task DeleteBrandAsync(int id, CancellationToken cancellationToken);
}