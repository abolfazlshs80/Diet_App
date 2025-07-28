using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.UserRole.GetAll;

public record GetAllUserRoleQueryResult(int TotalRecords, List<GetUserRoleItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetUserRoleItem(Guid Id, Guid RoleId, Guid UserId);
