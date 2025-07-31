


using Diet.Domain.Contract.DTOs.LifeCourse;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository;

public class LifeCourseRepository : ILifeCourseRepository
{

    private readonly DietDbContext _dbContext;

    public LifeCourseRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.lifeCourse.Entities.LifeCourse> ByIdAsync(Guid Id)
    {
        return await _dbContext.LifeCourse.AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<GetItemLifeCourseDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.LifeCourse
                         where d.Id == Id
                         select new GetItemLifeCourseDto(d.Id, d.Title, d.ParentId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }
    public async Task AddAsync(Domain.lifeCourse.Entities.LifeCourse LifeCourse)
    {
        await _dbContext.AddAsync(LifeCourse);
      
    }

    public void Update(Domain.lifeCourse.Entities.LifeCourse LifeCourse)
    {
        _dbContext.Update(LifeCourse);
       
    }

    public void Delete(Domain.lifeCourse.Entities.LifeCourse LifeCourse)
    {
        _dbContext.Remove(LifeCourse);
       
    }

    public async Task<List<GetItemLifeCourseDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.LifeCourse
                         select new GetItemLifeCourseDto(d.Id, d.Title, d.ParentId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.LifeCourse.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
