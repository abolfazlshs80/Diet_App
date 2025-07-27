using Diet.Domain.Contract.Commands.Role.Update;
using Order.Framework.Core.Bus;

public record UpdateRoleCommandResult(string state, string message) : ICommandResult;
