using Diet.Domain.Contract.Commands.Role.Delete;
using Order.Framework.Core.Bus;

public record DeleteRoleCommandResult(string state, string message) : ICommandResult;
