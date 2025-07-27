using Diet.Domain.disease.Repository;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository;

public class DiseaseRepository : IDiseaseRepository
{

    private readonly DietDbContext _dbContext;

    public DiseaseRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.disease.Disease> ByIdAsync(Guid Id)
    {
        return await _dbContext.Disease.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task AddAsync(Domain.disease.Disease Disease)
    {
        await _dbContext.AddAsync(Disease);
      
    }

    public async Task UpdateAsync(Domain.disease.Disease Disease)
    {
        _dbContext.Update(Disease);
       
    }

    public async Task DeleteAsync(Domain.disease.Disease Disease)
    {
        _dbContext.Remove(Disease);
       
    }

    public async Task<List<Domain.disease.Disease>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result =  _dbContext.Disease.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Title.Contains(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }

   
}
