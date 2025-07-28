using Diet.Domain.supplementGroup;
using Diet.Domain.supplementGroup.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.SupplementGroup;

public class SupplementGroupRepository : ISupplementGroupRepository
{
    private readonly DietDbContext _dbContext;

    public SupplementGroupRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.supplementGroup.SupplementGroup> ByIdAsync(Guid id)
    {
        return await _dbContext.SupplementGroup.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.supplementGroup.SupplementGroup supplementGroup)
    {
        await _dbContext.SupplementGroup.AddAsync(supplementGroup);
    }

    public async Task UpdateAsync(Diet.Domain.supplementGroup.SupplementGroup supplementGroup)
    {
        _dbContext.Update(supplementGroup);
    }

    public async Task DeleteAsync(Diet.Domain.supplementGroup.SupplementGroup supplementGroup)
    {
        _dbContext.Remove(supplementGroup);
    }

    public async Task<List<     Diet.Domain.supplementGroup.SupplementGroup>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.SupplementGroup.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
