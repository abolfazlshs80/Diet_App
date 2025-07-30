using Diet.Domain.Contract;
using Diet.Domain.Contract.DTOs.Drug;
using Diet.Domain.Contract.DTOs.DurationAge;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.user.Repository;

public interface IDrugRepository : IRepository
{

    Task<List<GetItemDrugDto>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<drug.Drug> ByIdAsync(Guid Id);
    Task<GetItemDrugDto> ByIdDtoAsync(Guid Id);
    Task<bool> IsExists(Guid Id);
    Task AddAsync(drug.Drug Drug);
    Task UpdateAsync(drug.Drug Drug);
    Task DeleteAsync(drug.Drug Drug);


}
