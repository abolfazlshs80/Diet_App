using Diet.Framework.Core.Interface;
namespace Diet.Domain.supplementDurationAge.Repository
{
    public interface ISupplementDurationAgeRepository : IRepository
    {
        Task<List<Diet.Domain.supplementDurationAge.SupplementDurationAge>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.supplementDurationAge.SupplementDurationAge> ByIdAsync(Guid id);

        Task AddAsync(Diet.Domain.supplementDurationAge.SupplementDurationAge supplementDurationAge);
        Task UpdateAsync(Diet.Domain.supplementDurationAge.SupplementDurationAge supplementDurationAge);
        Task DeleteAsync(Diet.Domain.supplementDurationAge.SupplementDurationAge supplementDurationAge);
    }
}
