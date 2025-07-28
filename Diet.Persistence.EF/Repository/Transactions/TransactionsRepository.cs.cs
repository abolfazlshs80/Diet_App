using Diet.Domain.transactions;
using Diet.Domain.transactions.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Transactions;

public class TransactionsRepository : ITransactionsRepository
{
    private readonly DietDbContext _dbContext;

    public TransactionsRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.transactions.Transactions> ByIdAsync(Guid id)
    {
        return await _dbContext.Transactions.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.transactions.Transactions transactions)
    {
        await _dbContext.Transactions.AddAsync(transactions);
    }

    public async Task UpdateAsync(Diet.Domain.transactions.Transactions transactions)
    {
        _dbContext.Update(transactions);
    }

    public async Task DeleteAsync(Diet.Domain.transactions.Transactions transactions)
    {
        _dbContext.Remove(transactions);
    }

    public async Task<List<     Diet.Domain.transactions.Transactions>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.Transactions.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.Transactions.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
