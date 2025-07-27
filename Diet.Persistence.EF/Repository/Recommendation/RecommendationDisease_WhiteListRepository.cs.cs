using Diet.Domain.recommendationDisease_WhiteList;
using Diet.Domain.recommendationDisease_WhiteList.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.RecommendationDisease_WhiteList;

public class RecommendationDisease_WhiteListRepository : IRecommendationDisease_WhiteListRepository
{
    private readonly DietDbContext _dbContext;

    public RecommendationDisease_WhiteListRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList> ByIdAsync(Guid id)
    {
        return await _dbContext.RecommendationDisease_WhiteList.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList recommendationDisease_WhiteList)
    {
        await _dbContext.RecommendationDisease_WhiteList.AddAsync(recommendationDisease_WhiteList);
    }

    public async Task UpdateAsync(Diet.Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList recommendationDisease_WhiteList)
    {
        _dbContext.Update(recommendationDisease_WhiteList);
    }

    public async Task DeleteAsync(Diet.Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList recommendationDisease_WhiteList)
    {
        _dbContext.Remove(recommendationDisease_WhiteList);
    }

    public async Task<List<     Diet.Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.RecommendationDisease_WhiteList.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
