using Diet.Domain.Contract.DTOs.UserRole;
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
    public async Task<GetItemUserRoleDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.UserRole
                         where d.Id == Id
                         select new GetItemUserRoleDto(d.Id, d.RoleId, d.UserId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(Diet.Domain.userRole.UserRole userRole)
    {
        await _dbContext.UserRole.AddAsync(userRole);
    }

    public void Update(Diet.Domain.userRole.UserRole userRole)
    {
        _dbContext.Update(userRole);
    }

    public void Delete(Diet.Domain.userRole.UserRole userRole)
    {
        _dbContext.Remove(userRole);
    }


    public async Task<List<GetItemUserRoleDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.UserRole
                         select new GetItemUserRoleDto(d.Id, d.RoleId, d.UserId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
}
