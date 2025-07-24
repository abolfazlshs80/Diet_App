

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateFoodFoodIntractionCommand( Guid FoodFistId, Guid FoodSecondId) : ICommand;
 