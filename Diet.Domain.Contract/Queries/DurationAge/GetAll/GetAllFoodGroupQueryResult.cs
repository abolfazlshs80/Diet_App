using Diet.Domain.Contract.DTOs.DurationAge;
using Diet.Domain.Contract.Queries.DurationAge.GetById;
using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.DurationAge.GetAll;

public record GetAllDurationAgeQueryResult(int TotalRecords, List<GetItemDurationAgeDto> Data, int CurrentPage, int PageSize): IQueryResult;
//public record GetDurationAgeItem(Guid Id,string Title, int MinAge, int MaxAge);

