using Microsoft.EntityFrameworkCore.Storage;

namespace ProductManagement.Service.UOW;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken cancellationToken = default);

    Task<IDbContextTransaction> BeginTransactionAsync();
}