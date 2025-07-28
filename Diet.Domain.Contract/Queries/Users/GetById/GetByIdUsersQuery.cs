using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Users.GetById;

public record GetByIdUsersQuery(Guid Id) : IQuery;
