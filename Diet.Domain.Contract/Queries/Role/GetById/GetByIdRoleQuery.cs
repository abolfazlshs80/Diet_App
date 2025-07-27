using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Role.GetById;

public record GetByIdRoleQuery(Guid Id) : IQuery;
