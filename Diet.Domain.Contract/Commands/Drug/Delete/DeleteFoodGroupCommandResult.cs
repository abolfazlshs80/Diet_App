using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Delete;

public record DeleteDrugCommandResult(string state, string message) : ICommandResult;
