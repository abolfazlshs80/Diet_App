using Diet.Domain.Contract.DTOs.Recommendation;
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
    public async Task<GetItemRecommendationDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.Recommendation
                         where d.Id == Id
                         select new GetItemRecommendationDto(d.Id, d.Title, d.EnglishTitle, d.Description, d.HowToUse)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }
    public async Task AddAsync(Diet.Domain.recommendation.Recommendation recommendation)
    {
        await _dbContext.Recommendation.AddAsync(recommendation);
    }

    public void Update(Diet.Domain.recommendation.Recommendation recommendation)
    {
        _dbContext.Update(recommendation);
    }

    public void Delete(Diet.Domain.recommendation.Recommendation recommendation)
    {
        _dbContext.Remove(recommendation);
    }

    public async Task<List<GetItemRecommendationDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.Recommendation
                         select new GetItemRecommendationDto(d.Id, d.Title, d.EnglishTitle, d.Description, d.HowToUse))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }

    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.Recommendation.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
