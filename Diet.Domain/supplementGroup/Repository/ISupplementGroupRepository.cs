using Diet.Domain.Contract.DTOs.SupplementGroup;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.supplementGroup.Repository
{
    public interface ISupplementGroupRepository : IRepository
    {
        Task<List<GetItemSupplementGroupDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.supplementGroup.SupplementGroup> ByIdAsync(Guid id);
        Task<GetItemSupplementGroupDto> ByIdDtoAsync(Guid id);

        Task<bool> IsExists(Guid Id);
        Task AddAsync(Diet.Domain.supplementGroup.SupplementGroup supplementGroup);
        void Update(Diet.Domain.supplementGroup.SupplementGroup supplementGroup);
        void Delete(Diet.Domain.supplementGroup.SupplementGroup supplementGroup);
    }
}
