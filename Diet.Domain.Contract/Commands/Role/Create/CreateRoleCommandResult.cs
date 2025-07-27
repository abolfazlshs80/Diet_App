using Diet.Domain.Contract.Commands.Role.Create;
using Order.Framework.Core.Bus;

public record CreateRoleCommandResult(string state, string message) : ICommandResult;
