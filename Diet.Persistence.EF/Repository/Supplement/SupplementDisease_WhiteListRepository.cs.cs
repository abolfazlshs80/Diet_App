using Diet.Domain.Contract.DTOs.SupplementDisease_WhiteList;
using Diet.Domain.supplementDisease_WhiteList;
using Diet.Domain.supplementDisease_WhiteList.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.SupplementDisease_WhiteList;

public class SupplementDisease_WhiteListRepository : ISupplementDisease_WhiteListRepository
{
    private readonly DietDbContext _dbContext;

    public SupplementDisease_WhiteListRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList> ByIdAsync(Guid id)
    {
        return await _dbContext.SupplementDisease_WhiteList.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task<GetItemSupplementDisease_WhiteListDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.SupplementDisease_WhiteList
                         where d.Id == Id
                         select new GetItemSupplementDisease_WhiteListDto(d.Id, d.SupplementId, d.DiseaseId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }
    public async Task AddAsync(Diet.Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList supplementDisease_WhiteList)
    {
        await _dbContext.SupplementDisease_WhiteList.AddAsync(supplementDisease_WhiteList);
    }

    public void Update(Diet.Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList supplementDisease_WhiteList)
    {
        _dbContext.Update(supplementDisease_WhiteList);
    }

    public void Delete(Diet.Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList supplementDisease_WhiteList)
    {
        _dbContext.Remove(supplementDisease_WhiteList);
    }

    public async Task<List<GetItemSupplementDisease_WhiteListDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.SupplementDisease_WhiteList
                         select new GetItemSupplementDisease_WhiteListDto(d.Id, d.SupplementId, d.DiseaseId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
}
