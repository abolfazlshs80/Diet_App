using Diet.Domain.Contract.DTOs.SupplementLifeCourse;
using Diet.Domain.supplementLifeCourse;
using Diet.Domain.supplementLifeCourse.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.SupplementLifeCourse;

public class SupplementLifeCourseRepository : ISupplementLifeCourseRepository
{
    private readonly DietDbContext _dbContext;

    public SupplementLifeCourseRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.supplementLifeCourse.SupplementLifeCourse> ByIdAsync(Guid id)
    {
        return await _dbContext.SupplementLifeCourse.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task<GetItemSupplementLifeCourseDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.SupplementLifeCourse
                         where d.Id == Id
                         select new GetItemSupplementLifeCourseDto(d.Id, d.SupplementId, d.LifeCourseId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(Diet.Domain.supplementLifeCourse.SupplementLifeCourse supplementLifeCourse)
    {
        await _dbContext.SupplementLifeCourse.AddAsync(supplementLifeCourse);
    }

    public void Update(Diet.Domain.supplementLifeCourse.SupplementLifeCourse supplementLifeCourse)
    {
        _dbContext.Update(supplementLifeCourse);
    }

    public void Delete(Diet.Domain.supplementLifeCourse.SupplementLifeCourse supplementLifeCourse)
    {
        _dbContext.Remove(supplementLifeCourse);
    }

    public async Task<List<GetItemSupplementLifeCourseDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.SupplementLifeCourse
                         select new GetItemSupplementLifeCourseDto(d.Id, d.SupplementId, d.LifeCourseId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
}
