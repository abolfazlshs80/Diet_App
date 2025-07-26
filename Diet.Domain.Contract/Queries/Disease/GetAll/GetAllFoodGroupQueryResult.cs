using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Disease.GetAll;

public record GetAllDiseaseQueryResult(int TotalRecords, List<GetDiseaseItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetDiseaseItem(Guid Id,string Title, Guid ParentId);

