using AutoMapper;
using ProductManagement.Repository.Criteria;
using ProductManagement.Repository.Entities;
using ProductManagement.Repository.Interfaces;
using ProductManagement.Service.Common.Exceptions;
using ProductManagement.Service.DTOs;
using ProductManagement.Service.Interfaces;
using ProductManagement.Service.UOW;

namespace ProductManagement.Service.Implementation;

public class ProductService : GenericService<Product>,
    IProductService
{
    #region Fields and Properties

    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    #endregion Fields and Properties

    #region Constructor

    public ProductService(IUnitOfWork unitOfWork,
        IProductRepository productRepository,
        IMapper mapper) : base(productRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion Constructor

    #region Interface Methods

    public async Task<ProductDto> AddProductAsync(ProductDto productDto,
        CancellationToken cancellationToken = default)
    {
        Product product = _mapper.Map<Product>(productDto);

        await AddAsync(product, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        productDto.Id = product.Id;

        return productDto;
    }

    public async Task<ProductDto> GetProudctAsync(int id,
        CancellationToken cancellationToken = default)
    {
        Product? product = await GetProductById(id, cancellationToken);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken)
    {
        PageFilterCriteria<Product> criteria = new()
        {
            IsPageRequest = false
        };

        (long _, IEnumerable<Product> data) = await GetAllAsync(criteria, cancellationToken);

        return _mapper.Map<IEnumerable<ProductDto>>(data);
    }

    public async Task DeleteProductAsync(int id,
        CancellationToken cancellationToken = default)
    {
        Product product = await GetProductById(id, cancellationToken);

        await RemoveAsync(product, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
    }

    public async Task<ProductDto> UpdateProductAsync(ProductDto productDto,
        CancellationToken cancellationToken = default)
    {
        Product product = await GetProductById(productDto.Id, cancellationToken);

        _mapper.Map(productDto, product);
        await UpdateAsync(product, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return productDto;
    }

    #endregion Interface Methods

    #region Helper Methods

    private async Task<Product> GetProductById(int id,
        CancellationToken cancellationToken = default)
    {
        Product? product = await GetFirstOrDefaultAsync(new()
        {
            Filter = product => product.Id == id
        }, cancellationToken);

        if (product is null) throw new ResourceNotFoundException($"Product with id {id} not found.");
        return product;
    }

    #endregion
}