using Diet.Domain.Contract.Commands.Users.Update;
using Order.Framework.Core.Bus;

public record UpdateUsersCommandResult(string state, string message) : ICommandResult;
