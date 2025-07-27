using Diet.Framework.Core.Interface;
namespace Diet.Domain.recommendationDurationAge.Repository
{
    public interface IRecommendationDurationAgeRepository : IRepository
    {
        Task<List<Diet.Domain.recommendationDurationAge.RecommendationDurationAge>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.recommendationDurationAge.RecommendationDurationAge> ByIdAsync(Guid id);

        Task AddAsync(Diet.Domain.recommendationDurationAge.RecommendationDurationAge recommendationDurationAge);
        Task UpdateAsync(Diet.Domain.recommendationDurationAge.RecommendationDurationAge recommendationDurationAge);
        Task DeleteAsync(Diet.Domain.recommendationDurationAge.RecommendationDurationAge recommendationDurationAge);
    }
}
