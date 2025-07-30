


using Diet.Domain.Contract.DTOs.CasePleasantFood;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.@CasePleasantFood.Repository;

public interface ICasePleasantFoodRepository : IRepository
{

    Task<List<GetItemCasePleasantFoodDto>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.casePleasantFood.CasePleasantFood> ByIdAsync(Guid Id);
    Task<GetItemCasePleasantFoodDto> ByIdDtoAsync(Guid Id);


    Task AddAsync(Domain.casePleasantFood.CasePleasantFood CasePleasantFood);
    Task UpdateAsync(Domain.casePleasantFood.CasePleasantFood CasePleasantFood);
    Task DeleteAsync(Domain.casePleasantFood.CasePleasantFood CasePleasantFood);
}
