using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.SupplementGroup.GetAll;

public record GetAllSupplementGroupQueryResult(int TotalRecords, List<GetSupplementGroupItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetSupplementGroupItem(Guid Id, string Title);
