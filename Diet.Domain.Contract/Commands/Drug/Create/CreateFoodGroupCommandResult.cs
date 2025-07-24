using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateDrugCommandResult(string state, string message) : ICommandResult;
