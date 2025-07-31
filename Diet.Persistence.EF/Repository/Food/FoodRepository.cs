


using Diet.Domain.Contract.DTOs.Food;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository;

public class FoodRepository : IFoodRepository
{

    private readonly DietDbContext _dbContext;

    public FoodRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.food.Entities.Food> ByIdAsync(Guid Id)
    {
        return await _dbContext.Food.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<GetItemFoodDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.Food
                         where d.Id == Id
                         select new GetItemFoodDto(d.Id, d.Title, d.Description, d.Value, d.FoodGroupId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }
    public async Task AddAsync(Domain.food.Entities.Food Food)
    {
        await _dbContext.AddAsync(Food);
      
    }

    public void Update(Domain.food.Entities.Food Food)
    {
        _dbContext.Update(Food);
       
    }

    public void Delete(Domain.food.Entities.Food Food)
    {
        _dbContext.Remove(Food);
       
    }


    public async Task<List<GetItemFoodDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.Food
                         select new GetItemFoodDto(d.Id, d.Title, d.Description, d.Value, d.FoodGroupId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }

    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.Food.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
