using Diet.Domain.Contract.DTOs.SupplementGroup;
using Diet.Domain.supplementGroup;
using Diet.Domain.supplementGroup.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.SupplementGroup;

public class SupplementGroupRepository : ISupplementGroupRepository
{
    private readonly DietDbContext _dbContext;

    public SupplementGroupRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.supplementGroup.SupplementGroup> ByIdAsync(Guid id)
    {
        return await _dbContext.SupplementGroup.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task<GetItemSupplementGroupDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.SupplementGroup
                         where d.Id == Id
                         select new GetItemSupplementGroupDto(d.Id, d.Title)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(Diet.Domain.supplementGroup.SupplementGroup supplementGroup)
    {
        await _dbContext.SupplementGroup.AddAsync(supplementGroup);
    }

    public void Update(Diet.Domain.supplementGroup.SupplementGroup supplementGroup)
    {
        _dbContext.Update(supplementGroup);
    }

    public void Delete(Diet.Domain.supplementGroup.SupplementGroup supplementGroup)
    {
        _dbContext.Remove(supplementGroup);
    }
    public async Task<List<GetItemSupplementGroupDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.SupplementGroup
                         select new GetItemSupplementGroupDto(d.Id, d.Title))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.SupplementGroup.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
