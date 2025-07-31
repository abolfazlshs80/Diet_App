using Diet.Domain.caseDrug;
using Diet.Domain.CaseDrug.Repository;
using Diet.Domain.Contract.DTOs.CaseDrug;
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

    public async Task<GetItemCaseDrugDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.CaseDrug
                         where d.Id == Id
                         select new GetItemCaseDrugDto(d.Id, d.CaseId, d.DrugId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(CaseDrug CaseDrug)
    {
        await _dbContext.CaseDrug.AddAsync(CaseDrug);

    }

    public void Update(CaseDrug CaseDrug)
    {
        _dbContext.Update(CaseDrug);

    }

    public void Delete(CaseDrug CaseDrug)
    {
        _dbContext.Remove(CaseDrug);

    }

    public async Task<List<GetItemCaseDrugDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.CaseDrug
                         select new GetItemCaseDrugDto(d.Id, d.CaseId, d.DrugId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }


}
