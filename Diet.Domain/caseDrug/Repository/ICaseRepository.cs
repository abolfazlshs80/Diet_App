


using Diet.Framework.Core.Interface;

namespace Diet.Domain.@CaseDrug.Repository;

public interface ICaseDrugRepository : IRepository
{

    Task<List<Domain.caseDrug. CaseDrug>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.caseDrug.CaseDrug> ByIdAsync(Guid Id);


    Task AddAsync(Domain.caseDrug.CaseDrug CaseDrug);
    Task UpdateAsync(Domain.caseDrug.CaseDrug CaseDrug);
    Task DeleteAsync(Domain.caseDrug.CaseDrug CaseDrug);
}
