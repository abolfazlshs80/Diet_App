using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Delete;

public record DeleteFoodGroupCommandResult(string state, string message) : ICommandResult;
