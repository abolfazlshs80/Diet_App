using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateCaseUnPleasantFoodCommandResult(string state, string message) : ICommandResult;
