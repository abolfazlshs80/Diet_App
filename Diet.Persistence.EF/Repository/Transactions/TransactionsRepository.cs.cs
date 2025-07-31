using Diet.Domain.Contract.DTOs.Transactions;
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

    public async Task<GetItemTransactionsDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.Transactions
                         where d.Id == Id
                         select new GetItemTransactionsDto(d.Id, d.TotalPrice, d.ZarinPalAuthority, d.ZarinPalRefNum, d.TransactionType)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(Diet.Domain.transactions.Transactions transactions)
    {
        await _dbContext.Transactions.AddAsync(transactions);
    }

    public void Update(Diet.Domain.transactions.Transactions transactions)
    {
        _dbContext.Update(transactions);
    }

    public void Delete(Diet.Domain.transactions.Transactions transactions)
    {
        _dbContext.Remove(transactions);
    }

    public async Task<List<GetItemTransactionsDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.Transactions
                         select new GetItemTransactionsDto(d.Id, d.TotalPrice, d.ZarinPalAuthority, d.ZarinPalRefNum, d.TransactionType))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.Transactions.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
