using Diet.Domain.userRole;
using Diet.Domain.userRole.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.UserRole;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly DietDbContext _dbContext;

    public UserRoleRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.userRole.UserRole> ByIdAsync(Guid id)
    {
        return await _dbContext.UserRole.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.userRole.UserRole userRole)
    {
        await _dbContext.UserRole.AddAsync(userRole);
    }

    public async Task UpdateAsync(Diet.Domain.userRole.UserRole userRole)
    {
        _dbContext.Update(userRole);
    }

    public async Task DeleteAsync(Diet.Domain.userRole.UserRole userRole)
    {
        _dbContext.Remove(userRole);
    }

    public async Task<List<     Diet.Domain.userRole.UserRole>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.UserRole.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
