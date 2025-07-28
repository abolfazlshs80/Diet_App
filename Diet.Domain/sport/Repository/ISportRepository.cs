using Diet.Framework.Core.Interface;

namespace Diet.Domain.sport.Repository
{
    public interface ISportRepository : IRepository
    {
        Task<List<Diet.Domain.sport.Sport>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.sport.Sport> ByIdAsync(Guid id);
        Task<bool> IsExists(Guid id);
        Task AddAsync(Diet.Domain.sport.Sport sport);
        Task UpdateAsync(Diet.Domain.sport.Sport sport);
        Task DeleteAsync(Diet.Domain.sport.Sport sport);
    }
}
