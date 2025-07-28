using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Supplement.GetAll;

public record GetAllSupplementQueryResult(int TotalRecords, List<GetSupplementItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetSupplementItem(Guid Id, string Title, string EnglishTitle, string Description, string HowToUse, Guid SupplementGroupId);
