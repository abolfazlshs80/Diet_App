using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Enums;
using ErrorOr;
using Microsoft.EntityFrameworkCore.Storage;
using Order.Persistence.EF.Context;


namespace Diet.Persistence.EF.Repository;

public class UnitOfWork : IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    private readonly DietDbContext _dbContext;

    public UnitOfWork(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task BeginTransactionAsync(CancellationToken ct = default)
    {
        if (_transaction != null)
            return;

        _transaction = await _dbContext.Database.BeginTransactionAsync(ct);
    }

    public async Task<ErrorOr<TransactionStatus>> CommitAsync(CancellationToken ct = default)
    {
        try
        {
            await _dbContext.SaveChangesAsync();
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
        catch
        {
            await RollbackAsync();
            return TransactionStatus.Error;
        }

        return TransactionStatus.Success;
    }

    public async Task RollbackAsync(CancellationToken ct = default)
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
    public async Task<int> SaveAsync(CancellationToken ct = default)
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _dbContext.Dispose();
    }
}