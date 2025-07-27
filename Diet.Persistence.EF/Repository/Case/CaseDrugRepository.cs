using Diet.Domain.caseDrug;
using Diet.Domain.CaseDrug.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Case;

public class CaseDrugRepository : ICaseDrugRepository
{

    private readonly DietDbContext _dbContext;

    public CaseDrugRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CaseDrug> ByIdAsync(Guid Id)
    {
        return await _dbContext.CaseDrug.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task AddAsync(CaseDrug CaseDrug)
    {
        await _dbContext.CaseDrug.AddAsync(CaseDrug);

    }

    public async Task UpdateAsync(CaseDrug CaseDrug)
    {
        _dbContext.Update(CaseDrug);

    }

    public async Task DeleteAsync(CaseDrug CaseDrug)
    {
        _dbContext.Remove(CaseDrug);

    }

    public async Task<List<CaseDrug>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result = _dbContext.CaseDrug.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.CaseId.Equals(searchText)|| _.DrugId.Equals(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }


}
