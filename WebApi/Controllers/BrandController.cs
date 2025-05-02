using BusinessLogic.Brands.Interfaces;
using BusinessLogic.Brands.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WashCar.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BrandController(IBrandService brandService) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateBrandAsync([FromBody] BrandRequest brandRequest, CancellationToken cancellationToken)
    {
        await brandService.CreateBrandAsync(brandRequest, cancellationToken);
        return NoContent();
    }

    [Authorize(Roles = "Admin,Employee,Customer")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBrandAsync(int id, CancellationToken cancellationToken)
    {
        var brand = await brandService.GetBrandByIdAsync(id, cancellationToken);
        return Ok(brand);
    }
    
    [Authorize(Roles = "Admin,Employee,Customer")]
    [HttpGet]
    public async Task<IActionResult> GetAllBrands(CancellationToken cancellationToken)
    {
        var brands = await brandService.GetAllBrandsAsync(cancellationToken);
        return Ok(brands);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBrandAsync(int id, [FromBody] BrandRequest  brandRequest, CancellationToken cancellationToken)
    {
        await brandService.UpdateBrandAsync(id, brandRequest, cancellationToken);
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBrandAsync(int id, CancellationToken cancellationToken)
    {
        await brandService.DeleteBrandAsync(id, cancellationToken);
        return NoContent();
    }
}