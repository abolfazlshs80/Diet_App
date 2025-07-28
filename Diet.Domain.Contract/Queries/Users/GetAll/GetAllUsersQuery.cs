using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Users.GetAll;

public record GetAllUsersQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
