using Microsoft.EntityFrameworkCore;
using ProductManagement.Repository.Contexts;
using ProductManagement.Repository.Criteria;
using ProductManagement.Repository.Interfaces;
using ProductManagement.Repository.QueryExtension;
using System.Linq.Expressions;

namespace ProductManagement.Repository.Implementation;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    #region Properties and private fields

    protected readonly AppDbContext _dbContext;

    private readonly DbSet<T> _dbSet;

    #endregion Properties and private fields

    #region Constructor

    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    #endregion Constructor

    #region Interface Methods

    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(filter, cancellationToken);

    public virtual async Task AddAsync(T model,
        CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(model, cancellationToken);

    public virtual async Task AddRangeAsync(IEnumerable<T> models,
        CancellationToken cancellationToken = default)
        => await _dbSet.AddRangeAsync(models, cancellationToken);

    public virtual async Task<T?> GetFirstOrDefaultAsync(FilterCriteria<T> criteria,
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = GetAll().EvaluateQuery(criteria);

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<(long count, IEnumerable<T> data)> GetAllAsync(PageFilterCriteria<T> criteria,
        CancellationToken cancellationToken = default)
    {
        return await Task.Run(async () =>
        {
            IQueryable<T> query = GetAll();

            (long count, IEnumerable<T> data) result =
                await query.EvaluatePageQuery(criteria, cancellationToken);

            return result;
        }, cancellationToken);
    }

    public virtual async Task RemoveAsync(T model,
        CancellationToken cancellationToken = default)
        => await Task.Run(() => _dbSet.Remove(model), cancellationToken);

    public virtual async Task UpdateAsync(T model,
        CancellationToken cancellationToken = default)
        => await Task.Run(() => _dbSet.Update(model), cancellationToken);

    public virtual async Task UpdateRangeAsync(IEnumerable<T> models,
        CancellationToken cancellationToken = default)
        => await Task.Run(() => _dbSet.UpdateRange(models), cancellationToken);

    #endregion Interface Methods

    #region Helper Methods

    private IQueryable<T> GetAll()
    => _dbSet.AsNoTracking().AsQueryable();

    #endregion Helper Methods
}