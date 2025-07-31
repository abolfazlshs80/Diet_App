using Diet.Domain.Contract.DTOs.RecommendationLifeCourse;
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
    public async Task<GetItemRecommendationLifeCourseDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.RecommendationLifeCourse
                         where d.Id == Id
                         select new GetItemRecommendationLifeCourseDto(d.Id, d.RecommendationId, d.LifeCourseId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse recommendationLifeCourse)
    {
        await _dbContext.RecommendationLifeCourse.AddAsync(recommendationLifeCourse);
    }

    public void Update(Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse recommendationLifeCourse)
    {
        _dbContext.Update(recommendationLifeCourse);
    }

    public void Delete(Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse recommendationLifeCourse)
    {
        _dbContext.Remove(recommendationLifeCourse);
    }

    public async Task<List<GetItemRecommendationLifeCourseDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.RecommendationLifeCourse
                         select new GetItemRecommendationLifeCourseDto(d.Id, d.RecommendationId, d.LifeCourseId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
}
