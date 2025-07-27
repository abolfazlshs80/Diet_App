using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.RecommendationDurationAge.GetById;

public record GetByIdRecommendationDurationAgeQuery(Guid Id) : IQuery;
