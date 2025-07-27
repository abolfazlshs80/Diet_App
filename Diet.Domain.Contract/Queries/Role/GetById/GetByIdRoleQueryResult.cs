using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Role.GetById;

public record GetByIdRoleQueryResult(Guid Id, string Name) : IQueryResult;
