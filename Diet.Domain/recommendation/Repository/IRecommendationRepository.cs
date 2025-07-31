using Diet.Domain.Contract.DTOs.Recommendation;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.recommendation.Repository
{
    public interface IRecommendationRepository : IRepository
    {
        Task<List<GetItemRecommendationDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.recommendation.Recommendation> ByIdAsync(Guid id);
        Task<GetItemRecommendationDto> ByIdDtoAsync(Guid id);
        Task<bool> IsExists(Guid Id);
        Task AddAsync(Diet.Domain.recommendation.Recommendation recommendation);
        void Update(Diet.Domain.recommendation.Recommendation recommendation);
        void Delete(Diet.Domain.recommendation.Recommendation recommendation);
    }
}
