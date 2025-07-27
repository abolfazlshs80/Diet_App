using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository;

public class FoodDrugIntractionRepository : IFoodDrugIntractionRepository
{

    private readonly DietDbContext _dbContext;

    public FoodDrugIntractionRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.food.Entities.Food_Drug_Intraction> ByIdAsync(Guid Id)
    {
        return await _dbContext.Food_Drug_Intraction.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task AddAsync(Domain.food.Entities.Food_Drug_Intraction FoodDrugIntraction)
    {
        await _dbContext.Food_Drug_Intraction.AddAsync(FoodDrugIntraction);

    }

    public async Task UpdateAsync(Domain.food.Entities.Food_Drug_Intraction FoodDrugIntraction)
    {
        _dbContext.Update(FoodDrugIntraction);

    }

    public async Task DeleteAsync(Domain.food.Entities.Food_Drug_Intraction FoodDrugIntraction)
    {
        _dbContext.Remove(FoodDrugIntraction);

    }

    public async Task<List<Domain.food.Entities.Food_Drug_Intraction>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result = _dbContext.Food_Drug_Intraction.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.FoodId.Equals(searchText)|| _.DrugId.Equals(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }


}
