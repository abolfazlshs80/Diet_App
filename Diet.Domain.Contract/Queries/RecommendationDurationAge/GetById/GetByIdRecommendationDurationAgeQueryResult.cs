using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.RecommendationDurationAge.GetById;

public record GetByIdRecommendationDurationAgeQueryResult(Guid Id, Guid RecommendationId, Guid DurationAgeId) : IQueryResult;
