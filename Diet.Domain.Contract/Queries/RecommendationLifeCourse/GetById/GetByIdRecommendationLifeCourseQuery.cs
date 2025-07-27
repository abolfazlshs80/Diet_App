using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.RecommendationLifeCourse.GetById;

public record GetByIdRecommendationLifeCourseQuery(Guid Id) : IQuery;
