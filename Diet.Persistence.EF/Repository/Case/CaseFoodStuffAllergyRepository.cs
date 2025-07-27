using Diet.Domain.caseFoodStuffAllergy;
using Diet.Domain.CaseFoodStuffAllergy;
using Diet.Domain.CaseFoodStuffAllergy;
using Diet.Domain.CaseFoodStuffAllergy.Repository;
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

    public async Task AddAsync(CaseFoodStuffAllergy CaseFoodStuffAllergy)
    {
        await _dbContext.CaseFoodStuffAllergy.AddAsync(CaseFoodStuffAllergy);

    }

    public async Task UpdateAsync(CaseFoodStuffAllergy CaseFoodStuffAllergy)
    {
        _dbContext.Update(CaseFoodStuffAllergy);

    }

    public async Task DeleteAsync(CaseFoodStuffAllergy CaseFoodStuffAllergy)
    {
        _dbContext.Remove(CaseFoodStuffAllergy);

    }

    public async Task<List<CaseFoodStuffAllergy>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result = _dbContext.CaseFoodStuffAllergy.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.CaseId.Equals(searchText)|| _.FoodStuffId.Equals(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }


}
