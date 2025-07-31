using Diet.Domain.caseSupplement;
using Diet.Domain.CaseSupplement;
using Diet.Domain.CaseSupplement;
using Diet.Domain.CaseSupplement.Repository;
using Diet.Domain.Contract.DTOs.CaseSupplement;
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

    public async Task<GetItemCaseSupplementDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.CaseSupplement
                         where d.Id == Id
                         select new GetItemCaseSupplementDto(d.Id, d.SupplementId, d.CaseId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(CaseSupplement CaseSupplement)
    {
        await _dbContext.CaseSupplement.AddAsync(CaseSupplement);

    }

    public void Update(CaseSupplement CaseSupplement)
    {
        _dbContext.Update(CaseSupplement);

    }

    public void Delete(CaseSupplement CaseSupplement)
    {
        _dbContext.Remove(CaseSupplement);

    }

    public async Task<List<GetItemCaseSupplementDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.CaseSupplement
                         select new GetItemCaseSupplementDto(d.Id, d.SupplementId, d.CaseId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }

}
