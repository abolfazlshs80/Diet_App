using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Recommendation.GetById;

public record GetByIdRecommendationQuery(Guid Id) : IQuery;
