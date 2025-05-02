namespace DataAccess.Repositories.Brand;

public interface IBrandRepository
{
    Task<Model.Brand> CreateBrandAsync(Model.Brand brand, CancellationToken cancellationToken = default);
    Task<Model.Brand?> GetBrandByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Model.Brand>> GetAllBrandsAsync(CancellationToken cancellationToken = default);
    Task UpdateBrandAsync(Model.Brand brand, CancellationToken cancellationToken = default);
    Task DeleteBrandAsync(Model.Brand brand, CancellationToken cancellationToken = default);
}