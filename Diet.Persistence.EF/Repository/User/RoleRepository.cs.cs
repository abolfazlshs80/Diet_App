using Diet.Domain.role;
using Diet.Domain.role.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Role;

public class RoleRepository : IRoleRepository
{
    private readonly DietDbContext _dbContext;

    public RoleRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.role.Role> ByIdAsync(Guid id)
    {
        return await _dbContext.Role.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.role.Role role)
    {
        await _dbContext.Role.AddAsync(role);
    }

    public async Task UpdateAsync(Diet.Domain.role.Role role)
    {
        _dbContext.Update(role);
    }

    public async Task DeleteAsync(Diet.Domain.role.Role role)
    {
        _dbContext.Remove(role);
    }

    public async Task<List<     Diet.Domain.role.Role>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.Role.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
