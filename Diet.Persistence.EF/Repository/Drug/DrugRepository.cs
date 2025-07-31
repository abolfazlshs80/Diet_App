using Diet.Domain.Contract.DTOs.Drug;
using Diet.Domain.Contract.DTOs.DurationAge;
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

    public void Update(Domain.drug.Drug Drug)
    {
        _dbContext.Update(Drug);
       
    }

    public void Delete(Domain.drug.Drug Drug)
    {
        _dbContext.Remove(Drug);
       
    }


    public async Task<GetItemDrugDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.Drug
                         where d.Id == Id
                         select new GetItemDrugDto(d.Id, d.Title, d.Description)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }
    public async Task<List<GetItemDrugDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.Drug
                         select new GetItemDrugDto(d.Id, d.Title, d.Description))
                            .Skip(pageNumber * pageCount)
                            .Take(pageCount)
                            .AsNoTracking()
                            .ToListAsync();
        return res!;

    }

    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.Drug.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
