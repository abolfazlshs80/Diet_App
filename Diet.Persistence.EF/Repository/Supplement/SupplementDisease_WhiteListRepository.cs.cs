using Diet.Domain.supplementDisease_WhiteList;
using Diet.Domain.supplementDisease_WhiteList.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.SupplementDisease_WhiteList;

public class SupplementDisease_WhiteListRepository : ISupplementDisease_WhiteListRepository
{
    private readonly DietDbContext _dbContext;

    public SupplementDisease_WhiteListRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList> ByIdAsync(Guid id)
    {
        return await _dbContext.SupplementDisease_WhiteList.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList supplementDisease_WhiteList)
    {
        await _dbContext.SupplementDisease_WhiteList.AddAsync(supplementDisease_WhiteList);
    }

    public async Task UpdateAsync(Diet.Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList supplementDisease_WhiteList)
    {
        _dbContext.Update(supplementDisease_WhiteList);
    }

    public async Task DeleteAsync(Diet.Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList supplementDisease_WhiteList)
    {
        _dbContext.Remove(supplementDisease_WhiteList);
    }

    public async Task<List<     Diet.Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.SupplementDisease_WhiteList.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
