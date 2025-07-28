using Diet.Framework.Core.Interface;
namespace Diet.Domain.userRole.Repository
{
    public interface IUserRoleRepository : IRepository
    {
        Task<List<Diet.Domain.userRole.UserRole>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.userRole.UserRole> ByIdAsync(Guid id);

        Task AddAsync(Diet.Domain.userRole.UserRole userRole);
        Task UpdateAsync(Diet.Domain.userRole.UserRole userRole);
        Task DeleteAsync(Diet.Domain.userRole.UserRole userRole);
    }
}
