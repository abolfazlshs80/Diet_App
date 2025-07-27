using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Recommendation.GetAll;

public record GetAllRecommendationQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
