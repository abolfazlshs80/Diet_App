


using Diet.Framework.Core.Interface;

namespace Diet.Domain.@CasePleasantFood.Repository;

public interface ICasePleasantFoodRepository : IRepository
{

    Task<List<Domain.casePleasantFood. CasePleasantFood>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.casePleasantFood.CasePleasantFood> ByIdAsync(Guid Id);


    Task AddAsync(Domain.casePleasantFood.CasePleasantFood CasePleasantFood);
    Task UpdateAsync(Domain.casePleasantFood.CasePleasantFood CasePleasantFood);
    Task DeleteAsync(Domain.casePleasantFood.CasePleasantFood CasePleasantFood);
}
