using Diet.Domain.Contract.DTOs.SupplementDurationAge;
using Diet.Domain.supplementDurationAge;
using Diet.Domain.supplementDurationAge.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.SupplementDurationAge;

public class SupplementDurationAgeRepository : ISupplementDurationAgeRepository
{
    private readonly DietDbContext _dbContext;

    public SupplementDurationAgeRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.supplementDurationAge.SupplementDurationAge> ByIdAsync(Guid id)
    {
        return await _dbContext.SupplementDurationAge.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task<GetItemSupplementDurationAgeDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.SupplementDurationAge
                         where d.Id == Id
                         select new GetItemSupplementDurationAgeDto(d.Id, d.SupplementId, d.DurationAgeId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(Diet.Domain.supplementDurationAge.SupplementDurationAge supplementDurationAge)
    {
        await _dbContext.SupplementDurationAge.AddAsync(supplementDurationAge);
    }

    public void Update(Diet.Domain.supplementDurationAge.SupplementDurationAge supplementDurationAge)
    {
        _dbContext.Update(supplementDurationAge);
    }

    public void Delete(Diet.Domain.supplementDurationAge.SupplementDurationAge supplementDurationAge)
    {
        _dbContext.Remove(supplementDurationAge);
    }

    public async Task<List<GetItemSupplementDurationAgeDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.SupplementDurationAge
                         select new GetItemSupplementDurationAgeDto(d.Id, d.SupplementId, d.DurationAgeId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
}
