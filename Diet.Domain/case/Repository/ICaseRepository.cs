


using Diet.Framework.Core.Interface;

namespace Diet.Domain.@case.Repository;

public interface ICaseRepository:IRepository
{

    Task<List<Diet.Domain.Case.Case>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Diet.Domain.Case.Case> ByIdAsync(Guid Id);
    Task<bool> IsExists(Guid Id);


    Task AddAsync(Diet.Domain.Case.Case Case);
    Task UpdateAsync(Diet.Domain.Case.Case Case);
    Task DeleteAsync(Diet.Domain.Case.Case Case);
}
