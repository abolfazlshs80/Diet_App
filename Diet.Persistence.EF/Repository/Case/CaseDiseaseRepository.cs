using Diet.Domain.caseDisease;
using Diet.Domain.CaseDisease.Repository;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Case;

public class CaseDiseaseRepository : ICaseDiseaseRepository
{

    private readonly DietDbContext _dbContext;

    public CaseDiseaseRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CaseDisease> ByIdAsync(Guid Id)
    {
        return await _dbContext.CaseDisease.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task AddAsync(CaseDisease CaseDisease)
    {
        await _dbContext.CaseDisease.AddAsync(CaseDisease);

    }

    public async Task UpdateAsync(CaseDisease CaseDisease)
    {
        _dbContext.Update(CaseDisease);

    }

    public async Task DeleteAsync(CaseDisease CaseDisease)
    {
        _dbContext.Remove(CaseDisease);

    }

    public async Task<List<CaseDisease>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result = _dbContext.CaseDisease.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.CaseId.Equals(searchText)|| _.DiseaseId.Equals(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }


}
