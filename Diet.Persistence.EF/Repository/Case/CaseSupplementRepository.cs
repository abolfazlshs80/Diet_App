using Diet.Domain.caseSupplement;
using Diet.Domain.CaseSupplement;
using Diet.Domain.CaseSupplement;
using Diet.Domain.CaseSupplement.Repository;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Case;

public class CaseSupplementRepository : ICaseSupplementRepository
{

    private readonly DietDbContext _dbContext;

    public CaseSupplementRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CaseSupplement > ByIdAsync(Guid Id)
    {
        return await _dbContext.CaseSupplement.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task AddAsync(CaseSupplement CaseSupplement)
    {
        await _dbContext.CaseSupplement.AddAsync(CaseSupplement);

    }

    public async Task UpdateAsync(CaseSupplement CaseSupplement)
    {
        _dbContext.Update(CaseSupplement);

    }

    public async Task DeleteAsync(CaseSupplement CaseSupplement)
    {
        _dbContext.Remove(CaseSupplement);

    }

    public async Task<List<CaseSupplement>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result = _dbContext.CaseSupplement.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.CaseId.Equals(searchText)|| _.SupplementId.Equals(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }


}
