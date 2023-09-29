using ProductManagement.Repository.Entities;
using ProductManagement.Service.DTOs;

namespace ProductManagement.Service.Interfaces;

public interface IProductService : IGenericService<Product>
{
    Task<ProductDto> AddProductAsync(ProductDto productDto,
        CancellationToken cancellationToken = default);

    Task DeleteProductAsync(int id,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken);

    Task<ProductDto> GetProudctAsync(int id,
        CancellationToken cancellationToken = default);

    Task<ProductDto> UpdateProductAsync(ProductDto productDto,
        CancellationToken cancellationToken);
}