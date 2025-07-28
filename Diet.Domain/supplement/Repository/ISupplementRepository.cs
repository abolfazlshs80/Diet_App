using Diet.Framework.Core.Interface;
namespace Diet.Domain.supplement.Repository
{
    public interface ISupplementRepository : IRepository
    {
        Task<List<Diet.Domain.supplement.Supplement>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.supplement.Supplement> ByIdAsync(Guid id);
        Task<bool> IsExists(Guid Id);

        Task AddAsync(Diet.Domain.supplement.Supplement supplement);
        Task UpdateAsync(Diet.Domain.supplement.Supplement supplement);
        Task DeleteAsync(Diet.Domain.supplement.Supplement supplement);
    }
}
