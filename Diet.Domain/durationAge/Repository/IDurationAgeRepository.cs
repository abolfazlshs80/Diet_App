using Diet.Domain.Contract;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.durationAge.Repository;

public interface IDurationAgeRepository:IRepository
{

    Task<List<Domain.durationAge.Entities.DurationAge>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.durationAge.Entities.DurationAge> ByIdAsync(Guid Id);

    Task<bool> IsExists(Guid Id);

    Task AddAsync(Domain.durationAge.Entities.DurationAge DurationAge);
    Task UpdateAsync(Domain.durationAge.Entities.DurationAge DurationAge);
    Task DeleteAsync(Domain.durationAge.Entities.DurationAge DurationAge);
}
