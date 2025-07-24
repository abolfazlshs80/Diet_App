using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateFoodFoodIntractionCommandResult(string state, string message) : ICommandResult;
