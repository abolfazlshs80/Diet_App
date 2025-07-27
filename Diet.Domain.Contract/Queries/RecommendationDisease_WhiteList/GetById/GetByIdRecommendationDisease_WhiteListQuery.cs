using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.RecommendationDisease_WhiteList.GetById;

public record GetByIdRecommendationDisease_WhiteListQuery(Guid Id) : IQuery;
