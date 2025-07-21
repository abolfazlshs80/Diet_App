using Diet.Domain.Contract;
using Order.Persistence.EF.Context;

namespace Diet.Persistence.EF.Repository
{
    public class UnitOfWorkService : IUnitOfWorkService
    {

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
    }
}