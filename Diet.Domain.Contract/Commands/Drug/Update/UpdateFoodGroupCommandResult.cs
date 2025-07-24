using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateDrugCommandResult(string state, string message) : ICommandResult;
