using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.UserRole.GetAll;

public record GetAllUserRoleQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
