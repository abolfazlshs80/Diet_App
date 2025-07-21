


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

    public async Task<FoodGroup> ById(Guid Id)
    {
        return await _dbContext.FoodGroup.SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task Save(FoodGroup FoodGroup)
    {
        await _dbContext.FoodGroup.AddAsync(FoodGroup);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(FoodGroup FoodGroup)
    {
        _dbContext.Update(FoodGroup);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(FoodGroup FoodGroup)
    {
        _dbContext.Remove(FoodGroup);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<FoodGroup>> All()
    {
        return await _dbContext.FoodGroup.ToListAsync();
    }

   
}
