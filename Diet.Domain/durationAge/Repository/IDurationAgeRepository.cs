using Diet.Domain.Contract;
using Diet.Domain.Contract.DTOs.DurationAge;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.durationAge.Repository;

public interface IDurationAgeRepository:IRepository
{

    Task<List<GetItemDurationAgeDto>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<DurationAge> ByIdAsync(Guid Id);
    Task<GetItemDurationAgeDto> ByIdDtoAsync(Guid Id);

    Task<bool> IsExists(Guid Id);

    Task AddAsync(DurationAge DurationAge);
    void Update(DurationAge DurationAge);
    void Delete(DurationAge DurationAge);
}
