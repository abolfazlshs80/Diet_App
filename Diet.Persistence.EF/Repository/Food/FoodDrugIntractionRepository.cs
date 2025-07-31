using Diet.Domain.Contract.DTOs.FoodDrugIntraction;
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
    public async Task<GetItemFood_Drug_IntractionDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.Food_Drug_Intraction
                         where d.Id == Id
                         select new GetItemFood_Drug_IntractionDto(d.Id, d.FoodId, d.DrugId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(Domain.food.Entities.Food_Drug_Intraction FoodDrugIntraction)
    {
        await _dbContext.Food_Drug_Intraction.AddAsync(FoodDrugIntraction);

    }

    public void Update(Domain.food.Entities.Food_Drug_Intraction FoodDrugIntraction)
    {
        _dbContext.Update(FoodDrugIntraction);

    }

    public void Delete(Domain.food.Entities.Food_Drug_Intraction FoodDrugIntraction)
    {
        _dbContext.Remove(FoodDrugIntraction);

    }

    public async Task<List<GetItemFood_Drug_IntractionDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.Food_Drug_Intraction
                         select new GetItemFood_Drug_IntractionDto(d.Id, d.FoodId, d.DrugId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
}
