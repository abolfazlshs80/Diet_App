


using Diet.Domain.Contract.DTOs.CaseDrug;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.@CaseDrug.Repository;

public interface ICaseDrugRepository : IRepository
{

    Task<List<GetItemCaseDrugDto>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.caseDrug.CaseDrug> ByIdAsync(Guid Id);
    Task<GetItemCaseDrugDto> ByIdDtoAsync(Guid Id);


    Task AddAsync(Domain.caseDrug.CaseDrug CaseDrug);
    void Update(Domain.caseDrug.CaseDrug CaseDrug);
    void Delete(Domain.caseDrug.CaseDrug CaseDrug);
}
