using Diet.Domain.Contract;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.user.Repository;

public interface IDrugRepository : IRepository
{

    Task<List<Domain.drug.Entities.Drug>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.drug.Entities.Drug> ByIdAsync(Guid Id);

    Task<bool> IsExists(Guid Id);
    Task AddAsync(Domain.drug.Entities.Drug Drug);
    Task UpdateAsync(Domain.drug.Entities.Drug Drug);
    Task DeleteAsync(Domain.drug.Entities.Drug Drug);
}
