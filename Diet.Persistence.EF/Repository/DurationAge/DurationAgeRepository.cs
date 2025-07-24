



using Diet.Domain.durationAge.Repository;
using Microsoft.EntityFrameworkCore;
using Order.Persistence.EF.Context;

namespace Diet.Persistence.EF.Repository;

public class DurationAgeRepository : IDurationAgeRepository
{

    private readonly DietDbContext _dbContext;

    public DurationAgeRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.durationAge.Entities.DurationAge> ByIdAsync(Guid Id)
    {
        return await _dbContext.DurationAge.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task AddAsync(Domain.durationAge.Entities.DurationAge DurationAge)
    {
        await _dbContext.AddAsync(DurationAge);
      
    }

    public async Task UpdateAsync(Domain.durationAge.Entities.DurationAge DurationAge)
    {
        _dbContext.Update(DurationAge);
       
    }

    public async Task DeleteAsync(Domain.durationAge.Entities.DurationAge DurationAge)
    {
        _dbContext.Remove(DurationAge);
       
    }

    public async Task<List<Domain.durationAge.Entities.DurationAge>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result =  _dbContext.DurationAge.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Title.Contains(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }

   
}
