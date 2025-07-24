

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateFoodDrugIntractionCommand(Guid FoodId,Guid DrugId) : ICommand;
 