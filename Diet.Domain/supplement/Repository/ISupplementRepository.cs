using Diet.Domain.Contract.DTOs.Supplement;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.supplement.Repository
{
    public interface ISupplementRepository : IRepository
    {
        Task<List<GetItemSupplementDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.supplement.Supplement> ByIdAsync(Guid id);
        Task<GetItemSupplementDto> ByIdDtoAsync(Guid id);
        Task<bool> IsExists(Guid Id);

        Task AddAsync(Diet.Domain.supplement.Supplement supplement);
        void Update(Diet.Domain.supplement.Supplement supplement);
        void Delete(Diet.Domain.supplement.Supplement supplement);
    }
}
