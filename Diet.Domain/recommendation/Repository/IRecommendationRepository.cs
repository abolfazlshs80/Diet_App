using Diet.Framework.Core.Interface;
namespace Diet.Domain.recommendation.Repository
{
    public interface IRecommendationRepository : IRepository
    {
        Task<List<Diet.Domain.recommendation.Recommendation>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.recommendation.Recommendation> ByIdAsync(Guid id);

        Task AddAsync(Diet.Domain.recommendation.Recommendation recommendation);
        Task UpdateAsync(Diet.Domain.recommendation.Recommendation recommendation);
        Task DeleteAsync(Diet.Domain.recommendation.Recommendation recommendation);
    }
}
