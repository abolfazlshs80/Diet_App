


using Diet.Framework.Core.Interface;

namespace Diet.Domain.@CaseFoodStuffAllergy.Repository;

public interface ICaseFoodStuffAllergyRepository : IRepository
{

    Task<List<Domain.caseFoodStuffAllergy. CaseFoodStuffAllergy>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.caseFoodStuffAllergy.CaseFoodStuffAllergy> ByIdAsync(Guid Id);


    Task AddAsync(Domain.caseFoodStuffAllergy.CaseFoodStuffAllergy CaseFoodStuffAllergy);
    Task UpdateAsync(Domain.caseFoodStuffAllergy.CaseFoodStuffAllergy CaseFoodStuffAllergy);
    Task DeleteAsync(Domain.caseFoodStuffAllergy.CaseFoodStuffAllergy CaseFoodStuffAllergy);
}
