using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.DurationAge.GetAll;

public record GetAllDurationAgeQueryResult(int TotalRecords, List<GetDurationAgeItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetDurationAgeItem(Guid Id,string Title);

