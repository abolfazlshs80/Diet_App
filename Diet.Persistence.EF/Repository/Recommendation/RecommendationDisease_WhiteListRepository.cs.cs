using Diet.Domain.Contract.DTOs.RecommendationDisease_WhiteList;
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
    public async Task<GetItemRecommendationDisease_WhiteListDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.RecommendationDisease_WhiteList
                         where d.Id == Id
                         select new GetItemRecommendationDisease_WhiteListDto(d.Id, d.RecommendationId, d.DiseaseId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(Diet.Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList recommendationDisease_WhiteList)
    {
        await _dbContext.RecommendationDisease_WhiteList.AddAsync(recommendationDisease_WhiteList);
    }

    public void Update(Diet.Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList recommendationDisease_WhiteList)
    {
        _dbContext.Update(recommendationDisease_WhiteList);
    }

    public void Delete(Diet.Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList recommendationDisease_WhiteList)
    {
        _dbContext.Remove(recommendationDisease_WhiteList);
    }

    public async Task<List<GetItemRecommendationDisease_WhiteListDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.RecommendationDisease_WhiteList
                         select new GetItemRecommendationDisease_WhiteListDto(d.Id, d.RecommendationId, d.DiseaseId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.RecommendationDisease_WhiteList.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
