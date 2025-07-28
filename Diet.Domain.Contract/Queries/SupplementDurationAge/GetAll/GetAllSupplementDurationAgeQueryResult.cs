using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.SupplementDurationAge.GetAll;

public record GetAllSupplementDurationAgeQueryResult(int TotalRecords, List<GetSupplementDurationAgeItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetSupplementDurationAgeItem(Guid Id, Guid SupplementId, Guid DurationAgeId);
