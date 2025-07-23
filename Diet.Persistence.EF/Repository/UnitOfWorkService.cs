using Diet.Domain.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Order.Persistence.EF.Context;

namespace Diet.Persistence.EF.Repository
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private IDbContextTransaction? _transaction;
        private readonly DietDbContext _dbContext;
        public UnitOfWorkService(DietDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> SaveAsync( CancellationToken ct=default)
        {
            var result = await _dbContext.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task BeginTransactionAsync(CancellationToken ct = default)
        {
            if (_transaction != null)
                return;

            _transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        }

        public async Task CommitAsync(CancellationToken ct = default)
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction has not been started.");

            await _dbContext.SaveChangesAsync(ct);
            await _transaction.CommitAsync(ct);
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task RollbackAsync(CancellationToken ct = default)
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync(ct);
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
}