using Diet.Domain.Contract.DTOs.Disease;
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
    public async Task<GetItemDiseaseDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.Disease
                         where d.Id == Id
                         select new GetItemDiseaseDto(d.Id, d.Title, d.ParentId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }
    public async Task AddAsync(Domain.disease.Disease Disease)
    {
        await _dbContext.AddAsync(Disease);
      
    }

    public void Update(Domain.disease.Disease Disease)
    {
        _dbContext.Update(Disease);
       
    }

    public void Delete(Domain.disease.Disease Disease)
    {
        _dbContext.Remove(Disease);
       
    }

    public async Task<List<GetItemDiseaseDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.Disease
                         select new GetItemDiseaseDto(d.Id, d.Title, d.ParentId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.Disease.AsNoTracking().AnyAsync(x => x.Id == id);
    }

}
