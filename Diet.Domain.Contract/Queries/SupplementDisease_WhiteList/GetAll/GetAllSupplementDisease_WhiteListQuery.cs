using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.SupplementDisease_WhiteList.GetAll;

public record GetAllSupplementDisease_WhiteListQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
