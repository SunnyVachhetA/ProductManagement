using ProductManagement.Repository.Criteria;
using ProductManagement.Repository.Interfaces;
using ProductManagement.Service.Interfaces;
using System.Linq.Expressions;

namespace ProductManagement.Service.Implementation;

public class GenericService<T> : IGenericService<T> where T : class
{
    #region Properties and private fields

    private readonly IGenericRepository<T> _repository;

    #endregion Properties and private fields

    #region Constructor

    public GenericService(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    #endregion Constructor

    #region Interface Methods

    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default)
        => await _repository.AnyAsync(filter, cancellationToken);

    public virtual async Task AddAsync(T model,
        CancellationToken cancellationToken = default)
        => await _repository.AddAsync(model, cancellationToken);

    public virtual async Task AddRangeAsync(IEnumerable<T> models,
        CancellationToken cancellationToken = default)
        => await _repository.AddRangeAsync(models, cancellationToken);

    public virtual async Task<T?> GetFirstOrDefaultAsync(FilterCriteria<T> criteria,
        CancellationToken cancellationToken = default)
        => await _repository.GetFirstOrDefaultAsync(criteria, cancellationToken);

    public virtual async Task<(long count, IEnumerable<T> data)> GetAllAsync(PageFilterCriteria<T> criteria,
        CancellationToken cancellationToken = default)
        => await _repository.GetAllAsync(criteria, cancellationToken);

    public virtual async Task RemoveAsync(T model,
        CancellationToken cancellationToken = default)
        => await _repository.RemoveAsync(model, cancellationToken);

    public virtual async Task UpdateAsync(T model,
        CancellationToken cancellationToken = default)
        => await _repository.UpdateAsync(model, cancellationToken);

    public virtual async Task UpdateRangeAsync(IEnumerable<T> models,
        CancellationToken cancellationToken = default)
        => await _repository.UpdateRangeAsync(models, cancellationToken);

    #endregion Interface Methods
}