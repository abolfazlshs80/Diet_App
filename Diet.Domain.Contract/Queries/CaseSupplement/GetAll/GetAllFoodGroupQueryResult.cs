using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseSupplement.GetAll;

public record GetAllCaseSupplementQueryResult(int TotalRecords, List<GetCaseSupplementItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetCaseSupplementItem(Guid Id, Guid CaseId, Guid SupplementId);

