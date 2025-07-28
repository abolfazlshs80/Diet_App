using Diet.Domain.Contract.Commands.UserRole.Delete;
using Order.Framework.Core.Bus;

public record DeleteUserRoleCommandResult(string state, string message) : ICommandResult;
