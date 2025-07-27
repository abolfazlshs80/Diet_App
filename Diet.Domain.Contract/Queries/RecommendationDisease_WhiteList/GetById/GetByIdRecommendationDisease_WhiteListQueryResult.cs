using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.RecommendationDisease_WhiteList.GetById;

public record GetByIdRecommendationDisease_WhiteListQueryResult(Guid Id, Guid RecommendationId, Guid DiseaseId) : IQueryResult;
