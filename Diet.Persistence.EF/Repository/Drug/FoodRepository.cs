using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository;

public class DrugRepository : IDrugRepository
{

    private readonly DietDbContext _dbContext;

    public DrugRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.drug.Drug> ByIdAsync(Guid Id)
    {
        return await _dbContext.Drug.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task AddAsync(Domain.drug.Drug Drug)
    {
        await _dbContext.AddAsync(Drug);
      
    }

    public async Task UpdateAsync(Domain.drug.Drug Drug)
    {
        _dbContext.Update(Drug);
       
    }

    public async Task DeleteAsync(Domain.drug.Drug Drug)
    {
        _dbContext.Remove(Drug);
       
    }

    public async Task<List<Domain.drug.Drug>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result =  _dbContext.Drug.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Title.Contains(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }

    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.Drug.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
