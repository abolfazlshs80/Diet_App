using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Sport.GetAll;

public record GetAllSportQueryResult(int TotalRecords, List<GetSportItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetSportItem(Guid Id, string Name, int Low, int Medium, int High);
