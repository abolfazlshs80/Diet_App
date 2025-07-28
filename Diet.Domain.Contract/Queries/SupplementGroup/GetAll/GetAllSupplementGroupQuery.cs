using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.SupplementGroup.GetAll;

public record GetAllSupplementGroupQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
