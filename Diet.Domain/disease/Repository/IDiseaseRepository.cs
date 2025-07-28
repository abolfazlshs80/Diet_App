using Diet.Domain.Contract;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.disease.Repository;

public interface IDiseaseRepository: IRepository
{

    Task<List<Disease>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Disease> ByIdAsync(Guid Id);

    Task<bool> IsExists(Guid Id);
    Task AddAsync(Disease Disease);
    Task UpdateAsync(Disease Disease);
    Task DeleteAsync(Disease Disease);
}
