using Diet.Domain.Contract.Commands.Users.Delete;
using Order.Framework.Core.Bus;

public record DeleteUsersCommandResult(string state, string message) : ICommandResult;
