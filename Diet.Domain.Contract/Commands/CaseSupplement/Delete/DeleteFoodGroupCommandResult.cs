using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Delete;

public record DeleteCaseSupplementCommandResult(string state, string message) : ICommandResult;
