using Diet.Domain.supplementDurationAge;
using Diet.Domain.supplementDurationAge.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.SupplementDurationAge;

public class SupplementDurationAgeRepository : ISupplementDurationAgeRepository
{
    private readonly DietDbContext _dbContext;

    public SupplementDurationAgeRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.supplementDurationAge.SupplementDurationAge> ByIdAsync(Guid id)
    {
        return await _dbContext.SupplementDurationAge.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.supplementDurationAge.SupplementDurationAge supplementDurationAge)
    {
        await _dbContext.SupplementDurationAge.AddAsync(supplementDurationAge);
    }

    public async Task UpdateAsync(Diet.Domain.supplementDurationAge.SupplementDurationAge supplementDurationAge)
    {
        _dbContext.Update(supplementDurationAge);
    }

    public async Task DeleteAsync(Diet.Domain.supplementDurationAge.SupplementDurationAge supplementDurationAge)
    {
        _dbContext.Remove(supplementDurationAge);
    }

    public async Task<List<     Diet.Domain.supplementDurationAge.SupplementDurationAge>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.SupplementDurationAge.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
