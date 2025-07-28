using Diet.Domain.Contract.Commands.Users.Create;
using Order.Framework.Core.Bus;

public record CreateUsersCommandResult(string state, string message) : ICommandResult;
