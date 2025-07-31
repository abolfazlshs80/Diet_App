using Diet.Domain.Contract.DTOs.RecommendationDurationAge;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.recommendationDurationAge.Repository
{
    public interface IRecommendationDurationAgeRepository : IRepository
    {
        Task<List<GetItemRecommendationDurationAgeDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.recommendationDurationAge.RecommendationDurationAge> ByIdAsync(Guid id);
        Task<GetItemRecommendationDurationAgeDto> ByIdDtoAsync(Guid id);

        Task AddAsync(Diet.Domain.recommendationDurationAge.RecommendationDurationAge recommendationDurationAge);
        void Update(Diet.Domain.recommendationDurationAge.RecommendationDurationAge recommendationDurationAge);
        void Delete(Diet.Domain.recommendationDurationAge.RecommendationDurationAge recommendationDurationAge);
    }
}
