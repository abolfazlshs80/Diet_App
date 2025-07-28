using Diet.Domain.supplement;
using Diet.Domain.supplement.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Supplement;

public class SupplementRepository : ISupplementRepository
{
    private readonly DietDbContext _dbContext;

    public SupplementRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.supplement.Supplement> ByIdAsync(Guid id)
    {
        return await _dbContext.Supplement.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.supplement.Supplement supplement)
    {
        await _dbContext.Supplement.AddAsync(supplement);
    }

    public async Task UpdateAsync(Diet.Domain.supplement.Supplement supplement)
    {
        _dbContext.Update(supplement);
    }

    public async Task DeleteAsync(Diet.Domain.supplement.Supplement supplement)
    {
        _dbContext.Remove(supplement);
    }

    public async Task<List<     Diet.Domain.supplement.Supplement>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.Supplement.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
