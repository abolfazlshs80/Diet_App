using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.SupplementDisease_WhiteList.GetAll;

public record GetAllSupplementDisease_WhiteListQueryResult(int TotalRecords, List<GetSupplementDisease_WhiteListItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetSupplementDisease_WhiteListItem(Guid Id, Guid SupplementId, Guid DiseaseId);
