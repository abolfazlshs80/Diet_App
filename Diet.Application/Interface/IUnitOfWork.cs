using Diet.Domain.Contract.Enums;
using ErrorOr;

namespace Diet.Application.Interface;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveAsync(CancellationToken ct = default);
    Task BeginTransactionAsync(CancellationToken ct = default);
    Task<ErrorOr<TransactionStatus>> CommitAsync(CancellationToken ct = default);
    Task RollbackAsync(CancellationToken ct = default);
}
