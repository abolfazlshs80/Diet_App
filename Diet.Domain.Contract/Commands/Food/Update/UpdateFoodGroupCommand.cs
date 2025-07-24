

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateFoodCommand(Guid Id, string Title, string Description, double Value, Guid FoodGroupId) : ICommand;
 