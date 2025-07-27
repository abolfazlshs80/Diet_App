using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateCaseUnPleasantFoodCommandResult(string state, string message) : ICommandResult;
