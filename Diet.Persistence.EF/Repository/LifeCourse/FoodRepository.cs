﻿


using Diet.Domain.user.Repository;

using Microsoft.EntityFrameworkCore;
using Order.Persistence.EF.Context;

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

    public async Task AddAsync(Domain.lifeCourse.Entities.LifeCourse LifeCourse)
    {
        await _dbContext.AddAsync(LifeCourse);
      
    }

    public async Task UpdateAsync(Domain.lifeCourse.Entities.LifeCourse LifeCourse)
    {
        _dbContext.Update(LifeCourse);
       
    }

    public async Task DeleteAsync(Domain.lifeCourse.Entities.LifeCourse LifeCourse)
    {
        _dbContext.Remove(LifeCourse);
       
    }

    public async Task<List<Domain.lifeCourse.Entities.LifeCourse>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0)
    {
        var result =  _dbContext.LifeCourse.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Title.Contains(searchText));
        return await result.Skip(PageNumber * pageCount).Take(pageCount).AsNoTracking().ToListAsync();
    }

   
}
