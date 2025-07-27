using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.RecommendationLifeCourse.GetById;

public record GetByIdRecommendationLifeCourseQueryResult(Guid Id, Guid RecommendationId, Guid LifeCourseId) : IQueryResult;
