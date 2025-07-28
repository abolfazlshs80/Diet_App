using Diet.Framework.Core.Interface;
namespace Diet.Domain.supplementGroup.Repository
{
    public interface ISupplementGroupRepository : IRepository
    {
        Task<List<Diet.Domain.supplementGroup.SupplementGroup>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.supplementGroup.SupplementGroup> ByIdAsync(Guid id);

        Task<bool> IsExists(Guid Id);
        Task AddAsync(Diet.Domain.supplementGroup.SupplementGroup supplementGroup);
        Task UpdateAsync(Diet.Domain.supplementGroup.SupplementGroup supplementGroup);
        Task DeleteAsync(Diet.Domain.supplementGroup.SupplementGroup supplementGroup);
    }
}
