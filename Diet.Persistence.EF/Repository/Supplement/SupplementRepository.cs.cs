using Diet.Domain.Contract.DTOs.Supplement;
using Diet.Domain.supplement;
using Diet.Domain.supplement.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Supplement;

public class SupplementRepository : ISupplementRepository
{
    private readonly DietDbContext _dbContext;

    public SupplementRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.supplement.Supplement> ByIdAsync(Guid id)
    {
        return await _dbContext.Supplement.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task<GetItemSupplementDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.Supplement
                         where d.Id == Id
                         select new GetItemSupplementDto(d.Id, d.Title, d.EnglishTitle, d.Description, d.HowToUse, d.SupplementGroupId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(Diet.Domain.supplement.Supplement supplement)
    {
        await _dbContext.Supplement.AddAsync(supplement);
    }

    public void Update(Diet.Domain.supplement.Supplement supplement)
    {
        _dbContext.Update(supplement);
    }

    public void Delete(Diet.Domain.supplement.Supplement supplement)
    {
        _dbContext.Remove(supplement);
    }

    public async Task<List<GetItemSupplementDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.Supplement
                         select new GetItemSupplementDto(d.Id, d.Title, d.EnglishTitle, d.Description, d.HowToUse, d.SupplementGroupId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }

    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.Supplement.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
