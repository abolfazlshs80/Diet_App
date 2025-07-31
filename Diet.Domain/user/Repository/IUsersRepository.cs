using Diet.Domain.Contract.DTOs.Users;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.user.Repository
{
    public interface IUsersRepository : IRepository
    {
        Task<List<string>> GetRolesByUserId(Guid userId);
        Task<User> GetUser( string mobile);
        Task<List<GetItemUsersDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Domain.user.User> ByIdAsync(Guid id);
        Task<GetItemUsersDto> ByIdDtoAsync(Guid id);
        Task<bool> IsExists(Guid id);
        Task AddAsync(Domain.user.User users);
        void Update(Domain.user.User users);
        void Delete(Domain.user.User users);
    }
}
