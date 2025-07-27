using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseDisease.GetAll;

public record GetAllCaseDiseaseQueryResult(int TotalRecords, List<GetCaseDiseaseItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetCaseDiseaseItem(Guid Id, Guid CaseId, Guid DiseaseId);

