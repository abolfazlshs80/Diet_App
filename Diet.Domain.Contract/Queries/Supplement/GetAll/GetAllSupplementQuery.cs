using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Supplement.GetAll;

public record GetAllSupplementQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
