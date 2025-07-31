using Diet.Domain.Contract.DTOs.RecommendationLifeCourse;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.recommendationLifeCourse.Repository
{
    public interface IRecommendationLifeCourseRepository : IRepository
    {
        Task<List<GetItemRecommendationLifeCourseDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse> ByIdAsync(Guid id);
        Task<GetItemRecommendationLifeCourseDto> ByIdDtoAsync(Guid id);

        Task AddAsync(Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse recommendationLifeCourse);
        void Update(Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse recommendationLifeCourse);
        void Delete(Diet.Domain.recommendationLifeCourse.RecommendationLifeCourse recommendationLifeCourse);
    }
}
