


using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;

using Microsoft.EntityFrameworkCore;
using Order.Persistence.EF.Context;

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

    public async Task AddAsync(Domain.food.Entities.FoodStuff FoodStuff)
    {
        await _dbContext.AddAsync(FoodStuff);
      
    }

    public async Task UpdateAsync(Domain.food.Entities.FoodStuff FoodStuff)
    {
        _dbContext.Update(FoodStuff);
       
    }

    public async Task DeleteAsync(Domain.food.Entities.FoodStuff FoodStuff)
    {
        _dbContext.Remove(FoodStuff);
       
    }

    public async Task<List<Domain.food.Entities.FoodStuff>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result =  _dbContext.FoodStuff.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Title.Contains(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }

   
}
