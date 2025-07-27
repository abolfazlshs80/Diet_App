using Diet.Domain.@case.Repository;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository;

public class CaseRepository : ICaseRepository
{

    private readonly DietDbContext _dbContext;

    public CaseRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.Case.Case> ByIdAsync(Guid Id)
    {
        return await _dbContext.Case.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task AddAsync(Domain.Case.Case Case)
    {
        await _dbContext.AddAsync(Case);
      
    }

    public async Task UpdateAsync(Domain.Case.Case Case)
    {
        _dbContext.Update(Case);
       
    }

    public async Task DeleteAsync(Domain.Case.Case Case)
    {
        _dbContext.Remove(Case);
       
    }

    public async Task<List<Domain.Case.Case>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result =  _dbContext.Case.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Description.Contains(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }

   
}
