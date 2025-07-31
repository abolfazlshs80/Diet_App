using Diet.Domain.Contract.DTOs.FoodFoodIntraction;
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
    public async Task<GetItemFood_Food_IntractionDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.Food_Food_Intraction
                         where d.Id == Id
                         select new GetItemFood_Food_IntractionDto(d.Id, d.FoodFistId, d.FoodSecondId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }
    public async Task AddAsync(Domain.food.Entities.Food_Food_Intraction FoodFoodIntraction)
    {
        await _dbContext.Food_Food_Intraction.AddAsync(FoodFoodIntraction);

    }

    public void Update(Domain.food.Entities.Food_Food_Intraction FoodFoodIntraction)
    {
        _dbContext.Update(FoodFoodIntraction);

    }

    public void Delete(Domain.food.Entities.Food_Food_Intraction FoodFoodIntraction)
    {
        _dbContext.Remove(FoodFoodIntraction);

    }
    public async Task<List<GetItemFood_Food_IntractionDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.Food_Food_Intraction
                         select new GetItemFood_Food_IntractionDto(d.Id, d.FoodFistId, d.FoodSecondId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }


}
