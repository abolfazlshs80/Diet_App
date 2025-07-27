using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseDrug.GetAll;

public record GetAllCaseDrugQueryResult(int TotalRecords, List<GetCaseDrugItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetCaseDrugItem(Guid Id, Guid CaseId, Guid DrugId);

