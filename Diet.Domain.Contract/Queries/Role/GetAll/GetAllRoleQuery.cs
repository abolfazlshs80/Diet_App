using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Role.GetAll;

public record GetAllRoleQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
