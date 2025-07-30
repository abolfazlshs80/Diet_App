


using Diet.Domain.Contract.DTOs.CaseDisease;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.@CaseDisease.Repository;

public interface ICaseDiseaseRepository : IRepository
{

    Task<List<GetItemCaseDiseaseDto>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.caseDisease.CaseDisease> ByIdAsync(Guid Id);
    Task<GetItemCaseDiseaseDto> ByIdDtoAsync(Guid Id);


    Task AddAsync(Domain.caseDisease.CaseDisease CaseDisease);
    Task UpdateAsync(Domain.caseDisease.CaseDisease CaseDisease);
    Task DeleteAsync(Domain.caseDisease.CaseDisease CaseDisease);
}
