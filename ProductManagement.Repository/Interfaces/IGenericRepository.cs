using ProductManagement.Repository.Criteria;
using System.Linq.Expressions;

namespace ProductManagement.Repository.Interfaces;
public interface IGenericRepository<T> where T : class
{
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default);

    Task AddAsync(T model,
        CancellationToken cancellationToken = default);

    Task AddRangeAsync(IEnumerable<T> models,
        CancellationToken cancellationToken = default);

    Task<T?> GetFirstOrDefaultAsync(FilterCriteria<T> criteria,
        CancellationToken cancellationToken = default);

    Task<(long count, IEnumerable<T> data)> GetAllAsync(PageFilterCriteria<T> criteria,
        CancellationToken cancellationToken = default);

    Task RemoveAsync(T model,
        CancellationToken cancellationToken = default);

    Task UpdateRangeAsync(IEnumerable<T> models,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(T model,
        CancellationToken cancellationToken = default);
}