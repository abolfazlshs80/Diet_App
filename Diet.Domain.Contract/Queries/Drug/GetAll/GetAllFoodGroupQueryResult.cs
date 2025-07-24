using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Drug.GetAll;

public record GetAllDrugQueryResult(int TotalRecords, List<GetDrugItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetDrugItem(Guid Id, string Title, string Description);

