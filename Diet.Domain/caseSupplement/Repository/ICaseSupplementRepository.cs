


using Diet.Framework.Core.Interface;

namespace Diet.Domain.@CaseSupplement.Repository;

public interface ICaseSupplementRepository : IRepository
{

    Task<List<Domain.caseSupplement. CaseSupplement>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.caseSupplement.CaseSupplement> ByIdAsync(Guid Id);


    Task AddAsync(Domain.caseSupplement.CaseSupplement CaseSupplement);
    Task UpdateAsync(Domain.caseSupplement.CaseSupplement CaseSupplement);
    Task DeleteAsync(Domain.caseSupplement.CaseSupplement CaseSupplement);
}
