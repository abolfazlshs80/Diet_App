using Diet.Domain.caseUnPleasantFood;
using Diet.Domain.CaseUnPleasantFood;
using Diet.Domain.CaseUnPleasantFood;
using Diet.Domain.CaseUnPleasantFood;
using Diet.Domain.CaseUnPleasantFood.Repository;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Case;

public class CaseUnPleasantFoodRepository : ICaseUnPleasantFoodRepository
{

    private readonly DietDbContext _dbContext;

    public CaseUnPleasantFoodRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CaseUnPleasantFood > ByIdAsync(Guid Id)
    {
        return await _dbContext.CaseUnPleasantFood.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task AddAsync(CaseUnPleasantFood CaseUnPleasantFood)
    {
        await _dbContext.CaseUnPleasantFood.AddAsync(CaseUnPleasantFood);

    }

    public async Task UpdateAsync(CaseUnPleasantFood CaseUnPleasantFood)
    {
        _dbContext.Update(CaseUnPleasantFood);

    }

    public async Task DeleteAsync(CaseUnPleasantFood CaseUnPleasantFood)
    {
        _dbContext.Remove(CaseUnPleasantFood);

    }

    public async Task<List<CaseUnPleasantFood>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result = _dbContext.CaseUnPleasantFood.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.CaseId.Equals(searchText)|| _.FoodId.Equals(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }


}
