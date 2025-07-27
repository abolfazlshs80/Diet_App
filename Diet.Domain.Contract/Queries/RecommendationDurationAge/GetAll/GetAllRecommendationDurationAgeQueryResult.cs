using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.RecommendationDurationAge.GetAll;

public record GetAllRecommendationDurationAgeQueryResult(int TotalRecords, List<GetRecommendationDurationAgeItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetRecommendationDurationAgeItem(Guid Id, Guid RecommendationId, Guid DurationAgeId);
