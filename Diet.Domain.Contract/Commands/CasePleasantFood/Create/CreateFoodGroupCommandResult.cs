using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateCasePleasantFoodCommandResult(string state, string message) : ICommandResult;
