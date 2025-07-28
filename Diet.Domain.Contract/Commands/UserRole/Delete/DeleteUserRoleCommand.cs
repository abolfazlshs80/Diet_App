using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.UserRole.Delete;

public record DeleteUserRoleCommand(Guid Id) : ICommand;
