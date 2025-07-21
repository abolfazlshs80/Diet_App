namespace Diet.Domain.Contract
{
    public interface IUnitOfWorkService
    {
        Task<bool> SaveAsync(CancellationToken ct = default);
    }
}