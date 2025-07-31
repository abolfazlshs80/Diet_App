using Diet.Domain.Contract.DTOs.Sport;
using Diet.Domain.Contract.DTOs.SupplementDisease_WhiteList;
using Diet.Domain.sport;
using Diet.Domain.sport.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Sport;

public class SportRepository : ISportRepository
{
    private readonly DietDbContext _dbContext;

    public SportRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.sport.Sport> ByIdAsync(Guid id)
    {
        return await _dbContext.Sport.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task<GetItemSportDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.Sport
                         where d.Id == Id
                         select new GetItemSportDto(d.Id, d.Name, d.Low, d.Medium, d.High)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(Diet.Domain.sport.Sport sport)
    {
        await _dbContext.Sport.AddAsync(sport);
    }

    public void Update(Diet.Domain.sport.Sport sport)
    {
        _dbContext.Update(sport);
    }

    public void Delete(Diet.Domain.sport.Sport sport)
    {
        _dbContext.Remove(sport);
    }
    public async Task<List<GetItemSportDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.Sport
                         select new GetItemSportDto(d.Id,d.Name,d.Low,d.Medium,d.High))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }

    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.Sport.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
