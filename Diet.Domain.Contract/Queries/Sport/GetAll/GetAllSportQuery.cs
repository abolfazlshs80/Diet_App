using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Sport.GetAll;

public record GetAllSportQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
