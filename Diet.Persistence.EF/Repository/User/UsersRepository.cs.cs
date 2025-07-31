using Diet.Domain.Contract.DTOs.Users;
using Diet.Domain.Contract.Enums;
using Diet.Domain.user;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

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

    public async Task<GetItemUsersDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.Users
                         where d.Id == Id
                         select new GetItemUsersDto(d.Id, d.FirstName, d.LastName, d.ImageName, d.ReferenceCode, d.VerifyCode, d.CardNumber, d.ShbaNumber, d.VerifyExpire, d.Deleted, d.CreateDate, d.BirthDay, d.Gender, d.MobileNumber, d.Password, d.Salt)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }
    public async Task AddAsync(Diet.Domain.user.User users)
    {
        await _dbContext.Users.AddAsync(users);
    }

    public void Update(Diet.Domain.user.User users)
    {
        _dbContext.Update(users);
    }

    public void Delete(Diet.Domain.user.User users)
    {
        _dbContext.Remove(users);
    }

    public async Task<List<GetItemUsersDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.Users
                         select new GetItemUsersDto(d.Id, d.FirstName, d.LastName, d.ImageName, d.ReferenceCode, d.VerifyCode, d.CardNumber, d.ShbaNumber, d.VerifyExpire, d.Deleted, d.CreateDate, d.BirthDay, (d.Gender), d.MobileNumber, d.Password, d.Salt))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }

    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.Users.AsNoTracking().AnyAsync(x => x.Id == id);
    }

    public async Task<List<string>> GetRolesByUserId(Guid userId)
    {
        var _user = await _dbContext.Users.Include(a=>a.UserRoles).SingleOrDefaultAsync(x => x.Id == userId);
        if (_user is not null &&_user.UserRoles.Any())
        {
            List<string> list = (from ur in _user.UserRoles
                                 join r in _dbContext.Role on ur.RoleId equals r.Id
                                 select r.Name).ToList<string>();
            return list;
        }
        return new List<string>();
    }

    public async Task<User> GetUser(string mobile)
    {

        return await _dbContext.Users.AsNoTracking()
            .SingleOrDefaultAsync(x =>  x.MobileNumber == mobile);
    }
}
