using Diet.Domain.Contract.Commands.UserRole.Update;
using Order.Framework.Core.Bus;

public record UpdateUserRoleCommandResult(string state, string message) : ICommandResult;
