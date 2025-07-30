



using Diet.Domain.Contract.DTOs.DurationAge;
using Diet.Domain.durationAge;
using Diet.Domain.durationAge.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository;

public class DurationAgeRepository : IDurationAgeRepository
{

    private readonly DietDbContext _dbContext;

    public DurationAgeRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task AddAsync(DurationAge DurationAge)
    {
        await _dbContext.AddAsync(DurationAge);
    }

    public void Update(DurationAge DurationAge)
    {
        _dbContext.Update(DurationAge);
    }

    public void Delete(DurationAge DurationAge)
    {
        _dbContext.Remove(DurationAge);
    }

    public async Task<List<GetItemDurationAgeDto>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var res = await (from d in _dbContext.DurationAge
                          where d.Title.Contains(searchText!)
                          select new GetItemDurationAgeDto(
                             d.Id,
                             d.Title,
                             d.MinAge,
                             d.MaxAge)
                        )
                        .Skip(PageNumber)
                        .Take(pageCount)
                        .AsNoTracking()
                        .ToListAsync();
        return res;
    }

    public async Task<bool> IsExists(Guid Id)
    {
        return await _dbContext.DurationAge.AnyAsync(x => x.Id == Id);
    }

    public async Task<DurationAge> ByIdAsync(Guid Id)
    {
        return await _dbContext.DurationAge.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<GetItemDurationAgeDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.DurationAge
                         where d.Id == Id
                         select new GetItemDurationAgeDto(
                               d.Id,
                               d.Title,
                               d.MinAge,
                               d.MaxAge
                             )
                        ).AsNoTracking().FirstOrDefaultAsync();

        return res!;

    }
}
