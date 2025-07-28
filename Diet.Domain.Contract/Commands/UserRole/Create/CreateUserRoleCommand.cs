using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.UserRole.Create;

public record CreateUserRoleCommand(Guid RoleId, Guid UserId) : ICommand;
