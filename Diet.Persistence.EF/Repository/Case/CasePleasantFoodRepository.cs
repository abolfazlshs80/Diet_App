using Diet.Domain.casePleasantFood;
using Diet.Domain.CasePleasantFood;
using Diet.Domain.CasePleasantFood.Repository;
using Diet.Domain.Contract.DTOs.CasePleasantFood;
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
    public async Task<GetItemCasePleasantFoodDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.CasePleasantFood
                         where d.Id == Id
                         select new GetItemCasePleasantFoodDto(d.Id, d.FoodId, d.CaseId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(CasePleasantFood CasePleasantFood)
    {
        await _dbContext.CasePleasantFood.AddAsync(CasePleasantFood);

    }

    public void Update(CasePleasantFood CasePleasantFood)
    {
        _dbContext.Update(CasePleasantFood);

    }

    public void Delete(CasePleasantFood CasePleasantFood)
    {
        _dbContext.Remove(CasePleasantFood);

    }
    public async Task<List<GetItemCasePleasantFoodDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.CasePleasantFood
                         select new GetItemCasePleasantFoodDto(d.Id, d.FoodId, d.CaseId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }


}
