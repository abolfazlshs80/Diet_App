using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.UserRole.GetById;

public record GetByIdUserRoleQueryResult(Guid Id, Guid RoleId, Guid UserId) : IQueryResult;
