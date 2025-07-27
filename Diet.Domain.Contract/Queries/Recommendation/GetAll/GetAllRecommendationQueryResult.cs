using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Recommendation.GetAll;

public record GetAllRecommendationQueryResult(int TotalRecords, List<GetRecommendationItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetRecommendationItem(Guid Id, string Title, string EnglishTitle, string Description, string HowToUse);
