using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.UserRole.GetById;

public record GetByIdUserRoleQuery(Guid Id) : IQuery;
