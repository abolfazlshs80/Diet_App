using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Recommendation.GetById;

public record GetByIdRecommendationQueryResult(Guid Id, string Title, string EnglishTitle, string Description, string HowToUse) : IQueryResult;
