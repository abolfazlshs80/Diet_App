using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateFoodFoodIntractionCommandResult(string state, string message) : ICommandResult;
