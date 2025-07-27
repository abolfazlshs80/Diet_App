

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateCaseUnPleasantFoodCommand(Guid Id, Guid CaseId, Guid FoodId) : ICommand;
 