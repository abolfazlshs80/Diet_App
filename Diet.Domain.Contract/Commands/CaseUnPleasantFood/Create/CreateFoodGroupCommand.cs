

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateCaseUnPleasantFoodCommand(  Guid CaseId, Guid FoodId) : ICommand;
 