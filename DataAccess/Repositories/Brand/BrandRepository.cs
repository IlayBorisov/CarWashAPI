using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Brand;

public class BrandRepository(DbContext context) : IBrandRepository
{
    public async Task<Model.Brand> CreateBrandAsync(Model.Brand brand, CancellationToken cancellationToken = default)
    {
        await context.Brands.AddAsync(brand, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return brand;
    }
    
    public async Task<Model.Brand?> GetBrandByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Brands
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }
    
    public async Task<IEnumerable<Model.Brand>> GetAllBrandsAsync(CancellationToken cancellationToken = default)
    {
        return await context.Brands.ToListAsync(cancellationToken);
    }
    
    public async Task UpdateBrandAsync(Model.Brand brand, CancellationToken cancellationToken = default)
    {
        context.Brands.Update(brand);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteBrandAsync(Model.Brand brand, CancellationToken cancellationToken = default)
    {
        context.Brands.Remove(brand);
        await context.SaveChangesAsync(cancellationToken);
    }
}