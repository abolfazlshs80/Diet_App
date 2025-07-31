


using Diet.Domain.Contract.DTOs.FoodStuff;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository;

public class FoodStuffRepository : IFoodStuffRepository
{

    private readonly DietDbContext _dbContext;

    public FoodStuffRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.food.Entities.FoodStuff> ByIdAsync(Guid Id)
    {
        return await _dbContext.FoodStuff.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }
    public async Task<GetItemFoodStuffDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.FoodStuff
                         where d.Id == Id
                         select new GetItemFoodStuffDto(d.Id, d.Title)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }
    public async Task AddAsync(Domain.food.Entities.FoodStuff FoodStuff)
    {
        await _dbContext.AddAsync(FoodStuff);
      
    }

    public void Update(Domain.food.Entities.FoodStuff FoodStuff)
    {
        _dbContext.Update(FoodStuff);
       
    }

    public void Delete(Domain.food.Entities.FoodStuff FoodStuff)
    {
        _dbContext.Remove(FoodStuff);
       
    }

    public async Task<List<GetItemFoodStuffDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.FoodStuff
                         select new GetItemFoodStuffDto(d.Id, d.Title))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.FoodStuff.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
