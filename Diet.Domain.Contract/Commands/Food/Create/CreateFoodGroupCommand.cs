

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateFoodCommand(string Title, string Description, double Value, Guid FoodGroupId) : ICommand;
 