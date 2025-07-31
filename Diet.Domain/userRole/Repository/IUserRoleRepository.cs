using Diet.Domain.Contract.DTOs.UserRole;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.userRole.Repository
{
    public interface IUserRoleRepository : IRepository
    {
        Task<List<GetItemUserRoleDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.userRole.UserRole> ByIdAsync(Guid id);
        Task<GetItemUserRoleDto> ByIdDtoAsync(Guid id);

        Task AddAsync(Diet.Domain.userRole.UserRole userRole);
        void Update(Diet.Domain.userRole.UserRole userRole);
        void Delete(Diet.Domain.userRole.UserRole userRole);
    }
}
