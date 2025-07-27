using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.RecommendationLifeCourse.GetAll;

public record GetAllRecommendationLifeCourseQueryResult(int TotalRecords, List<GetRecommendationLifeCourseItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetRecommendationLifeCourseItem(Guid Id, Guid RecommendationId, Guid LifeCourseId);
