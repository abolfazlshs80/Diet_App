using Diet.Domain.sport;
using Diet.Domain.sport.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Sport;

public class SportRepository : ISportRepository
{
    private readonly DietDbContext _dbContext;

    public SportRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.sport.Sport> ByIdAsync(Guid id)
    {
        return await _dbContext.Sport.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.sport.Sport sport)
    {
        await _dbContext.Sport.AddAsync(sport);
    }

    public async Task UpdateAsync(Diet.Domain.sport.Sport sport)
    {
        _dbContext.Update(sport);
    }

    public async Task DeleteAsync(Diet.Domain.sport.Sport sport)
    {
        _dbContext.Remove(sport);
    }

    public async Task<List<     Diet.Domain.sport.Sport>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.Sport.AsQueryable();
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
        return await _dbContext.Sport.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
