using Diet.Domain.Contract.DTOs.SupplementDisease_WhiteList;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.supplementDisease_WhiteList.Repository
{
    public interface ISupplementDisease_WhiteListRepository : IRepository
    {
        Task<List<GetItemSupplementDisease_WhiteListDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList> ByIdAsync(Guid id);
        Task<GetItemSupplementDisease_WhiteListDto> ByIdDtoAsync(Guid id);

        Task AddAsync(Diet.Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList supplementDisease_WhiteList);
        Task UpdateAsync(Diet.Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList supplementDisease_WhiteList);
        Task DeleteAsync(Diet.Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList supplementDisease_WhiteList);
    }
}
