using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.RecommendationDurationAge.GetAll;

public record GetAllRecommendationDurationAgeQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
