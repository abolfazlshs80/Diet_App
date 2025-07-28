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

    public async Task AddAsync(Diet.Domain.supplementLifeCourse.SupplementLifeCourse supplementLifeCourse)
    {
        await _dbContext.SupplementLifeCourse.AddAsync(supplementLifeCourse);
    }

    public async Task UpdateAsync(Diet.Domain.supplementLifeCourse.SupplementLifeCourse supplementLifeCourse)
    {
        _dbContext.Update(supplementLifeCourse);
    }

    public async Task DeleteAsync(Diet.Domain.supplementLifeCourse.SupplementLifeCourse supplementLifeCourse)
    {
        _dbContext.Remove(supplementLifeCourse);
    }

    public async Task<List<     Diet.Domain.supplementLifeCourse.SupplementLifeCourse>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.SupplementLifeCourse.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
