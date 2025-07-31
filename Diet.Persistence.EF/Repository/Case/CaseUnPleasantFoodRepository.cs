using Diet.Domain.caseUnPleasantFood;
using Diet.Domain.CaseUnPleasantFood;
using Diet.Domain.CaseUnPleasantFood;
using Diet.Domain.CaseUnPleasantFood;
using Diet.Domain.CaseUnPleasantFood.Repository;
using Diet.Domain.Contract.DTOs.CaseUnPleasantFood;
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
    public async Task<GetItemCaseUnPleasantFoodDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.CaseUnPleasantFood
                         where d.Id == Id
                         select new GetItemCaseUnPleasantFoodDto(d.Id, d.FoodId, d.CaseId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(CaseUnPleasantFood CaseUnPleasantFood)
    {
        await _dbContext.CaseUnPleasantFood.AddAsync(CaseUnPleasantFood);

    }

    public void Update(CaseUnPleasantFood CaseUnPleasantFood)
    {
        _dbContext.Update(CaseUnPleasantFood);

    }

    public void Delete(CaseUnPleasantFood CaseUnPleasantFood)
    {
        _dbContext.Remove(CaseUnPleasantFood);

    }

    public async Task<List<GetItemCaseUnPleasantFoodDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.CaseUnPleasantFood
                         select new GetItemCaseUnPleasantFoodDto(d.Id, d.FoodId, d.CaseId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }


}
