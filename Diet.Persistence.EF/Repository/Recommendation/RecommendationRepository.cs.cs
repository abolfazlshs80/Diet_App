using Diet.Domain.recommendation;
using Diet.Domain.recommendation.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Recommendation;

public class RecommendationRepository : IRecommendationRepository
{
    private readonly DietDbContext _dbContext;

    public RecommendationRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.recommendation.Recommendation> ByIdAsync(Guid id)
    {
        return await _dbContext.Recommendation.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.recommendation.Recommendation recommendation)
    {
        await _dbContext.Recommendation.AddAsync(recommendation);
    }

    public async Task UpdateAsync(Diet.Domain.recommendation.Recommendation recommendation)
    {
        _dbContext.Update(recommendation);
    }

    public async Task DeleteAsync(Diet.Domain.recommendation.Recommendation recommendation)
    {
        _dbContext.Remove(recommendation);
    }

    public async Task<List<     Diet.Domain.recommendation.Recommendation>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.Recommendation.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
