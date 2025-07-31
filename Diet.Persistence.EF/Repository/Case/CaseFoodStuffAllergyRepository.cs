using Diet.Domain.caseFoodStuffAllergy;
using Diet.Domain.CaseFoodStuffAllergy;
using Diet.Domain.CaseFoodStuffAllergy;
using Diet.Domain.CaseFoodStuffAllergy.Repository;
using Diet.Domain.Contract.DTOs.CaseFoodStuffAllergy;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Case;

public class CaseFoodStuffAllergyRepository : ICaseFoodStuffAllergyRepository
{

    private readonly DietDbContext _dbContext;

    public CaseFoodStuffAllergyRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CaseFoodStuffAllergy> ByIdAsync(Guid Id)
    {
        return await _dbContext.CaseFoodStuffAllergy.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }
    public async Task<GetItemCaseFoodStuffAllergyDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.CaseFoodStuffAllergy
                         where d.Id == Id
                         select new GetItemCaseFoodStuffAllergyDto(d.Id, d.FoodStuffId, d.CaseId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(CaseFoodStuffAllergy CaseFoodStuffAllergy)
    {
        await _dbContext.CaseFoodStuffAllergy.AddAsync(CaseFoodStuffAllergy);

    }

    public void Update(CaseFoodStuffAllergy CaseFoodStuffAllergy)
    {
        _dbContext.Update(CaseFoodStuffAllergy);

    }

    public void Delete(CaseFoodStuffAllergy CaseFoodStuffAllergy)
    {
        _dbContext.Remove(CaseFoodStuffAllergy);

    }
    public async Task<List<GetItemCaseFoodStuffAllergyDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.CaseFoodStuffAllergy
                         select new GetItemCaseFoodStuffAllergyDto(d.Id, d.FoodStuffId, d.CaseId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }

}
