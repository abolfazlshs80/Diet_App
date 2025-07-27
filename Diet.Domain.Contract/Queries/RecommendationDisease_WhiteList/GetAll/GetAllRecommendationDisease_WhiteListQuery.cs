using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.RecommendationDisease_WhiteList.GetAll;

public record GetAllRecommendationDisease_WhiteListQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
