


using Diet.Domain.Contract.DTOs.CaseSupplement;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.@CaseSupplement.Repository;

public interface ICaseSupplementRepository : IRepository
{

    Task<List<GetItemCaseSupplementDto>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.caseSupplement.CaseSupplement> ByIdAsync(Guid Id);
    Task<GetItemCaseSupplementDto> ByIdDtoAsync(Guid Id);


    Task AddAsync(Domain.caseSupplement.CaseSupplement CaseSupplement);
    void Update(Domain.caseSupplement.CaseSupplement CaseSupplement);
    void Delete(Domain.caseSupplement.CaseSupplement CaseSupplement);
}
