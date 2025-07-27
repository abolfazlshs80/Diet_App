using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository;

public class FoodFoodIntractionRepository : IFoodFoodIntractionRepository
{

    private readonly DietDbContext _dbContext;

    public FoodFoodIntractionRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.food.Entities.Food_Food_Intraction> ByIdAsync(Guid Id)
    {
        return await _dbContext.Food_Food_Intraction.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task AddAsync(Domain.food.Entities.Food_Food_Intraction FoodFoodIntraction)
    {
        await _dbContext.Food_Food_Intraction.AddAsync(FoodFoodIntraction);

    }

    public async Task UpdateAsync(Domain.food.Entities.Food_Food_Intraction FoodFoodIntraction)
    {
        _dbContext.Update(FoodFoodIntraction);

    }

    public async Task DeleteAsync(Domain.food.Entities.Food_Food_Intraction FoodFoodIntraction)
    {
        _dbContext.Remove(FoodFoodIntraction);

    }

    public async Task<List<Domain.food.Entities.Food_Food_Intraction>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result = _dbContext.Food_Food_Intraction.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.FoodSecondId.Equals(searchText)|| _.FoodFistId.Equals(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }


}
