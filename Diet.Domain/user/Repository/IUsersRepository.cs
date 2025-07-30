using Diet.Framework.Core.Interface;
namespace Diet.Domain.user.Repository
{
    public interface IUsersRepository : IRepository
    {
        Task<List<string>> GetRolesByUserId(Guid userId);
        Task<User> GetUser( string mobile);
        Task<List<Domain.user.User>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Domain.user.User> ByIdAsync(Guid id);
        Task<bool> IsExists(Guid id);
        Task AddAsync(Domain.user.User users);
        Task UpdateAsync(Domain.user.User users);
        Task DeleteAsync(Domain.user.User users);
    }
}
