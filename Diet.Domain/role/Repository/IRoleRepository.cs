using Diet.Framework.Core.Interface;
namespace Diet.Domain.role.Repository
{
    public interface IRoleRepository : IRepository
    {
        Task<List<Diet.Domain.role.Role>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.role.Role> ByIdAsync(Guid id);

        Task AddAsync(Diet.Domain.role.Role role);
        Task UpdateAsync(Diet.Domain.role.Role role);
        Task DeleteAsync(Diet.Domain.role.Role role);
    }
}
