using Diet.Domain.Contract.DTOs.Role;
using Diet.Domain.Contract.Enums;
using Diet.Domain.role;
using Diet.Domain.role.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Diet.Persistence.EF.Repository.Role;

public class RoleRepository : IRoleRepository
{
    private readonly DietDbContext _dbContext;

    public RoleRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Domain.role.Role> GetByName(EnumeRole enumRole)
    {
        return await _dbContext.Role.SingleOrDefaultAsync(x => x.Name == enumRole.ToString());
    }

    public async Task<Diet.Domain.role.Role> ByIdAsync(Guid id)
    {
        return await _dbContext.Role.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task<GetItemRoleDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.Role
                         where d.Id == Id
                         select new GetItemRoleDto(d.Id, d.Name)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }
    public async Task AddAsync(Diet.Domain.role.Role role)
    {
        await _dbContext.Role.AddAsync(role);
    }

    public void Update(Diet.Domain.role.Role role)
    {
        _dbContext.Update(role);
    }

    public void Delete(Diet.Domain.role.Role role)
    {
        _dbContext.Remove(role);
    }

    public async Task<List<GetItemRoleDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.Role
                         select new GetItemRoleDto(d.Id, d.Name))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.Role.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
