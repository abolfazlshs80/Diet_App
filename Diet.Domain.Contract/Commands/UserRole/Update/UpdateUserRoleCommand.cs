using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.UserRole.Update;

public record UpdateUserRoleCommand(Guid Id, Guid RoleId, Guid UserId) : ICommand;
