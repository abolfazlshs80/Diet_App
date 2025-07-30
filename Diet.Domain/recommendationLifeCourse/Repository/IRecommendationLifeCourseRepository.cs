using Diet.Domain.Contract.DTOs.RecommendationLifeCourse;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.recommendationLifeCourse.Repository
{
    public interface IRecommendationLifeCourseRepository : IRepository
    {
        Task<List<GetItemRecommendationLifeCourseDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse> ByIdAsync(Guid id);
        Task<GetItemRecommendationLifeCourseDto> ByIdADtosync(Guid id);

        Task AddAsync(Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse recommendationLifeCourse);
        Task UpdateAsync(Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse recommendationLifeCourse);
        Task DeleteAsync(Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse recommendationLifeCourse);
    }
}
