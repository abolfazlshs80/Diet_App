using Diet.Domain.Contract.DTOs.RecommendationDisease_WhiteList;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.recommendationDisease_WhiteList.Repository
{
    public interface IRecommendationDisease_WhiteListRepository : IRepository
    {
        Task<List<GetItemRecommendationDisease_WhiteListDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList> ByIdAsync(Guid id);
        Task<GetItemRecommendationDisease_WhiteListDto> ByIdDtoAsync(Guid id);
        Task<bool> IsExists(Guid Id);
        Task AddAsync(Diet.Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList recommendationDisease_WhiteList);
        Task UpdateAsync(Diet.Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList recommendationDisease_WhiteList);
        Task DeleteAsync(Diet.Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList recommendationDisease_WhiteList);
    }
}
