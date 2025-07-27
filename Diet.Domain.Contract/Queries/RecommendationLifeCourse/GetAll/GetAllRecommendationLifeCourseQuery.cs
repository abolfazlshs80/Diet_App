using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.RecommendationLifeCourse.GetAll;

public record GetAllRecommendationLifeCourseQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
