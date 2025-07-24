

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateFoodFoodIntractionCommand(Guid Id, Guid FoodFistId, Guid FoodSecondId) : ICommand;
 