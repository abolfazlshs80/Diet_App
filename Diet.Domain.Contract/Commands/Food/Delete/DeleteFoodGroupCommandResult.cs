using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Delete;

public record DeleteFoodCommandResult(string state, string message) : ICommandResult;
