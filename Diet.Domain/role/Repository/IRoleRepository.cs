using Diet.Domain.Contract.DTOs.Role;
using Diet.Domain.Contract.Enums;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.role.Repository
{
    public interface IRoleRepository : IRepository
    {
        Task<Domain.role.Role> GetByName(EnumeRole enumRole);
        Task<List<GetItemRoleDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.role.Role> ByIdAsync(Guid id);
        Task<GetItemRoleDto> ByIdDtoAsync(Guid id);
        Task<bool> IsExists(Guid id);
        Task AddAsync(Diet.Domain.role.Role role);
        void Update(Diet.Domain.role.Role role);
        void Delete(Diet.Domain.role.Role role);
    }
}
