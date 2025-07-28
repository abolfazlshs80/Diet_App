using Diet.Domain.user;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Users;

public class UsersRepository : IUsersRepository
{
    private readonly DietDbContext _dbContext;

    public UsersRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.user.User> ByIdAsync(Guid id)
    {
        return await _dbContext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.user.User users)
    {
        await _dbContext.Users.AddAsync(users);
    }

    public async Task UpdateAsync(Diet.Domain.user.User users)
    {
        _dbContext.Update(users);
    }

    public async Task DeleteAsync(Diet.Domain.user.User users)
    {
        _dbContext.Remove(users);
    }

    public async Task<List<     Diet.Domain.user.User>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.Users.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
