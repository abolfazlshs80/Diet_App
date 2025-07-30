


using Diet.Domain.Contract.DTOs.CaseUnPleasantFood;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.@CaseUnPleasantFood.Repository;

public interface ICaseUnPleasantFoodRepository : IRepository
{

    Task<List<GetItemCaseUnPleasantFoodDto>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.caseUnPleasantFood.CaseUnPleasantFood> ByIdAsync(Guid Id);
    Task<GetItemCaseUnPleasantFoodDto> ByIdDtoAsync(Guid Id);


    Task AddAsync(Domain.caseUnPleasantFood.CaseUnPleasantFood CaseUnPleasantFood);
    Task UpdateAsync(Domain.caseUnPleasantFood.CaseUnPleasantFood CaseUnPleasantFood);
    Task DeleteAsync(Domain.caseUnPleasantFood.CaseUnPleasantFood CaseUnPleasantFood);
}
