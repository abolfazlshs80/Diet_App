using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Account.Register;

public record RegisterUserCommandResult(string state, string message) : ICommandResult;
