using Diet.Domain.Contract.DTOs.SupplementDurationAge;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.supplementDurationAge.Repository
{
    public interface ISupplementDurationAgeRepository : IRepository
    {
        Task<List<GetItemSupplementDurationAgeDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.supplementDurationAge.SupplementDurationAge> ByIdAsync(Guid id);
        Task<GetItemSupplementDurationAgeDto> ByIdDtoAsync(Guid id);

        Task AddAsync(Diet.Domain.supplementDurationAge.SupplementDurationAge supplementDurationAge);
        void Update(Diet.Domain.supplementDurationAge.SupplementDurationAge supplementDurationAge);
        void Delete(Diet.Domain.supplementDurationAge.SupplementDurationAge supplementDurationAge);
    }
}
