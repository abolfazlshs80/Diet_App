


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

    public async Task AddAsync(Domain.food.Entities.Food Food)
    {
        await _dbContext.AddAsync(Food);
      
    }

    public async Task UpdateAsync(Domain.food.Entities.Food Food)
    {
        _dbContext.Update(Food);
       
    }

    public async Task DeleteAsync(Domain.food.Entities.Food Food)
    {
        _dbContext.Remove(Food);
       
    }

    public async Task<List<Domain.food.Entities.Food>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result =  _dbContext.Food.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Title.Contains(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }

   
}
