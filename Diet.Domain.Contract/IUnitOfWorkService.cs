namespace Diet.Domain.Contract
{
    public interface IUnitOfWorkService
    {
        Task<bool> SaveAsync(CancellationToken ct = default);
        Task BeginTransactionAsync(CancellationToken ct = default);
        Task CommitAsync(CancellationToken ct = default);
        Task RollbackAsync(CancellationToken ct = default);
    }
}