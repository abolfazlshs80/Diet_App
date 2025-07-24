using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateFoodCommandResult(string state, string message) : ICommandResult;
