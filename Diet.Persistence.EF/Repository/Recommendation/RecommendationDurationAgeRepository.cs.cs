using Diet.Domain.recommendationDurationAge;
using Diet.Domain.recommendationDurationAge.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.RecommendationDurationAge;

public class RecommendationDurationAgeRepository : IRecommendationDurationAgeRepository
{
    private readonly DietDbContext _dbContext;

    public RecommendationDurationAgeRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.recommendationDurationAge.RecommendationDurationAge> ByIdAsync(Guid id)
    {
        return await _dbContext.RecommendationDurationAge.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.recommendationDurationAge.RecommendationDurationAge recommendationDurationAge)
    {
        await _dbContext.RecommendationDurationAge.AddAsync(recommendationDurationAge);
    }

    public async Task UpdateAsync(Diet.Domain.recommendationDurationAge.RecommendationDurationAge recommendationDurationAge)
    {
        _dbContext.Update(recommendationDurationAge);
    }

    public async Task DeleteAsync(Diet.Domain.recommendationDurationAge.RecommendationDurationAge recommendationDurationAge)
    {
        _dbContext.Remove(recommendationDurationAge);
    }

    public async Task<List<     Diet.Domain.recommendationDurationAge.RecommendationDurationAge>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.RecommendationDurationAge.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
