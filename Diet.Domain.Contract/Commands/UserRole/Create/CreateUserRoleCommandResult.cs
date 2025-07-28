using Diet.Domain.Contract.Commands.UserRole.Create;
using Order.Framework.Core.Bus;

public record CreateUserRoleCommandResult(string state, string message) : ICommandResult;
