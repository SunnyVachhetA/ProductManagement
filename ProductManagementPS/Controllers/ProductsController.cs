using CurrencySol.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Service.DTOs;
using ProductManagement.Service.Interfaces;

namespace ProductManagementPS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    #region Fields and properties

    private readonly IProductService _productService;

    #endregion Fields and properties

    #region Constructor

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    #endregion Constructor

    #region Http Methods

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto productDto,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _productService.AddProductAsync(productDto, cancellationToken);
        return ResponseHelper.CreateResourceResponse(productDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id,
        CancellationToken cancellationToken)
    {
        ProductDto productDto = await _productService.GetProudctAsync(id, cancellationToken);

        return ResponseHelper.SuccessResponse(productDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        IEnumerable<ProductDto> products = await _productService.GetAllProductsAsync(cancellationToken);

        return ResponseHelper.SuccessResponse(products);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id,
        CancellationToken cancellationToken)
    {
        await _productService.DeleteProductAsync(id, cancellationToken);

        return ResponseHelper.SuccessResponse(null);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditProduct(int id,
        ProductDto productDto,
        CancellationToken cancellationToken)
    {
        productDto.Id = id;

        productDto = await _productService.UpdateProductAsync(productDto, cancellationToken);

        return ResponseHelper.SuccessResponse(productDto);
    }
    #endregion Http Methods
}