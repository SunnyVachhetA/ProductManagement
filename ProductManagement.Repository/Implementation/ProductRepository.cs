using ProductManagement.Repository.Contexts;
using ProductManagement.Repository.Entities;
using ProductManagement.Repository.Interfaces;

namespace ProductManagement.Repository.Implementation;

public class ProductRepository : GenericRepository<Product>,
    IProductRepository
{
    #region Constructor

    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    #endregion Constructor
}