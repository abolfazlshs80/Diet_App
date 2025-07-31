using Diet.Domain.caseDisease;
using Diet.Domain.CaseDisease.Repository;
using Diet.Domain.Contract.DTOs.CaseDisease;
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
    public async Task<GetItemCaseDiseaseDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.CaseDisease
                         where d.Id == Id
                         select new GetItemCaseDiseaseDto(d.Id, d.CaseId, d.DiseaseId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }
    public async Task AddAsync(CaseDisease CaseDisease)
    {
        await _dbContext.CaseDisease.AddAsync(CaseDisease);

    }

    public void Update(CaseDisease CaseDisease)
    {
        _dbContext.Update(CaseDisease);

    }

    public void Delete(CaseDisease CaseDisease)
    {
        _dbContext.Remove(CaseDisease);

    }

    public async Task<List<GetItemCaseDiseaseDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.CaseDisease
                         select new GetItemCaseDiseaseDto(d.Id, d.CaseId, d.DiseaseId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }


}
