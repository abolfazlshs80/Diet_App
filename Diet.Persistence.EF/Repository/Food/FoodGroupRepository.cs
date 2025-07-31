


using Diet.Domain.Contract.DTOs.FoodGroup;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository;

public class FoodGroupRepository : IFoodGroupRepository
{

    private readonly DietDbContext _dbContext;

    public FoodGroupRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.food.Entities.FoodGroup> ByIdAsync(Guid Id)
    {
        return await _dbContext.FoodGroup.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }
    public async Task<GetItemFoodGroupDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.FoodGroup
                         where d.Id == Id
                         select new GetItemFoodGroupDto(d.Id, d.Title)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }
    public async Task AddAsync(Domain.food.Entities.FoodGroup FoodGroup)
    {
        await _dbContext.FoodGroup.AddAsync(FoodGroup);
      
    }

    public void Update(Domain.food.Entities.FoodGroup FoodGroup)
    {
        _dbContext.Update(FoodGroup);
       
    }

    public void Delete(Domain.food.Entities.FoodGroup FoodGroup)
    {
        _dbContext.Remove(FoodGroup);
       
    }

    public async Task<List<GetItemFoodGroupDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.FoodGroup
                         select new GetItemFoodGroupDto(d.Id, d.Title))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.FoodGroup.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
