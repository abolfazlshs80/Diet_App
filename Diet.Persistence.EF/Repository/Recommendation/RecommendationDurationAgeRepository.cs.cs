using Diet.Domain.Contract.DTOs.RecommendationDurationAge;
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
    public async Task<GetItemRecommendationDurationAgeDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.RecommendationDurationAge
                         where d.Id == Id
                         select new GetItemRecommendationDurationAgeDto(d.Id, d.RecommendationId, d.DurationAgeId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(Diet.Domain.recommendationDurationAge.RecommendationDurationAge recommendationDurationAge)
    {
        await _dbContext.RecommendationDurationAge.AddAsync(recommendationDurationAge);
    }

    public void Update(Diet.Domain.recommendationDurationAge.RecommendationDurationAge recommendationDurationAge)
    {
        _dbContext.Update(recommendationDurationAge);
    }

    public void Delete(Diet.Domain.recommendationDurationAge.RecommendationDurationAge recommendationDurationAge)
    {
        _dbContext.Remove(recommendationDurationAge);
    }
    public async Task<List<GetItemRecommendationDurationAgeDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.RecommendationDurationAge
                         select new GetItemRecommendationDurationAgeDto(d.Id, d.RecommendationId, d.DurationAgeId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
}
