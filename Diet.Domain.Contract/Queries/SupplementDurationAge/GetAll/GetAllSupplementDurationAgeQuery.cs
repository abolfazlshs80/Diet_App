using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.SupplementDurationAge.GetAll;

public record GetAllSupplementDurationAgeQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
