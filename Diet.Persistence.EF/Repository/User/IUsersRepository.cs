using Diet.Framework.Core.Interface;
namespace Diet.Domain.users.Repository
{
    public interface IUsersRepository : IRepository
    {
        Task<List<Diet.Domain.user.User>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.user.User> ByIdAsync(Guid id);

        Task AddAsync(Diet.Domain.user.User users);
        Task UpdateAsync(Diet.Domain.user.User users);
        Task DeleteAsync(Diet.Domain.user.User users);
    }
}
