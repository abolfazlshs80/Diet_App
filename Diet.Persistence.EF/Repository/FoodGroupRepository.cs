


using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;

using Microsoft.EntityFrameworkCore;
using Order.Persistence.EF.Context;

namespace Diet.Persistence.EF.Repository;

public class FoodGroupRepository : IFoodGroupRepository
{

    private readonly DietDbContext _dbContext;

    public FoodGroupRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.food.Entities.FoodGroup> ById(Guid Id)
    {
        return await _dbContext.FoodGroup.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task Save(Domain.food.Entities.FoodGroup FoodGroup)
    {
        await _dbContext.FoodGroup.AddAsync(FoodGroup);
      
    }

    public async Task Update(Domain.food.Entities.FoodGroup FoodGroup)
    {
        _dbContext.Update(FoodGroup);
       
    }

    public async Task Delete(Domain.food.Entities.FoodGroup FoodGroup)
    {
        _dbContext.Remove(FoodGroup);
       
    }

    public async Task<List<Domain.food.Entities.FoodGroup>> All(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result =  _dbContext.FoodGroup.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Title.Contains(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }

   
}
