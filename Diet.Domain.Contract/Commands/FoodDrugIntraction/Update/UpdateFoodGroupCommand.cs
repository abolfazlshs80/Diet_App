

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateFoodDrugIntractionCommand(Guid Id,Guid FoodId,Guid DrugId) : ICommand;
 