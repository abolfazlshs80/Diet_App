using Diet.Domain.@case.Repository;
using Diet.Domain.Contract.DTOs.Case;
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
    public async Task<GetItemCaseDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.Case
                         where d.Id == Id
                         select new GetItemCaseDto(d.Id, d.Weight, d.Height, d.BirthDate, d.Description, d.Gender, d.BodyActivity, d.IsSport, d.SportActivity, d.ChangeWeightType, d.WeightChangeAmount, d.ExerciseTime, d.SportId.Value, d.ExerciseDay, d.DateOfStart, d.BodyForm, d.LifeCourseId, d.UserId, d.TransactionId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(Domain.Case.Case Case)
    {
        await _dbContext.AddAsync(Case);
      
    }

    public void Update(Domain.Case.Case Case)
    {
        _dbContext.Update(Case);
       
    }

    public void Delete(Domain.Case.Case Case)
    {
        _dbContext.Remove(Case);
       
    }

    public async Task<List<GetItemCaseDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.Case
                         select new GetItemCaseDto(d.Id, d.Weight, d.Height, d.BirthDate, d.Description, d.Gender, d.BodyActivity, d.IsSport, d.SportActivity, d.ChangeWeightType, d.WeightChangeAmount, d.ExerciseTime, d.SportId.Value, d.ExerciseDay, d.DateOfStart, d.BodyForm, d.LifeCourseId, d.UserId, d.TransactionId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.Case.AsNoTracking().AnyAsync(x => x.Id == id);
    }

}
