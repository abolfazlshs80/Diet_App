using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.RecommendationDisease_WhiteList.GetAll;

public record GetAllRecommendationDisease_WhiteListQueryResult(int TotalRecords, List<GetRecommendationDisease_WhiteListItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetRecommendationDisease_WhiteListItem(Guid Id, Guid RecommendationId, Guid DiseaseId);
