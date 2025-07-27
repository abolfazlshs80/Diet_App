using Diet.Domain.casePleasantFood;
using Diet.Domain.CasePleasantFood;
using Diet.Domain.CasePleasantFood.Repository;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Case;

public class CasePleasantFoodRepository : ICasePleasantFoodRepository
{

    private readonly DietDbContext _dbContext;

    public CasePleasantFoodRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CasePleasantFood > ByIdAsync(Guid Id)
    {
        return await _dbContext.CasePleasantFood.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task AddAsync(CasePleasantFood CasePleasantFood)
    {
        await _dbContext.CasePleasantFood.AddAsync(CasePleasantFood);

    }

    public async Task UpdateAsync(CasePleasantFood CasePleasantFood)
    {
        _dbContext.Update(CasePleasantFood);

    }

    public async Task DeleteAsync(CasePleasantFood CasePleasantFood)
    {
        _dbContext.Remove(CasePleasantFood);

    }

    public async Task<List<CasePleasantFood>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result = _dbContext.CasePleasantFood.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.CaseId.Equals(searchText)|| _.FoodId.Equals(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }


}
