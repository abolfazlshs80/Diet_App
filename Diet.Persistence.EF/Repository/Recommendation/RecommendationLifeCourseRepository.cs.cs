using Diet.Domain.recommendationLifeCourse;
using Diet.Domain.recommendationLifeCourse.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.RecommendationLifeCourse;

public class RecommendationLifeCourseRepository : IRecommendationLifeCourseRepository
{
    private readonly DietDbContext _dbContext;

    public RecommendationLifeCourseRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse> ByIdAsync(Guid id)
    {
        return await _dbContext.RecommendationLifeCourse.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse recommendationLifeCourse)
    {
        await _dbContext.RecommendationLifeCourse.AddAsync(recommendationLifeCourse);
    }

    public async Task UpdateAsync(Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse recommendationLifeCourse)
    {
        _dbContext.Update(recommendationLifeCourse);
    }

    public async Task DeleteAsync(Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse recommendationLifeCourse)
    {
        _dbContext.Remove(recommendationLifeCourse);
    }

    public async Task<List<     Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.RecommendationLifeCourse.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
