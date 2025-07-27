

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateCasePleasantFoodCommand(Guid Id, Guid CaseId, Guid FoodId) : ICommand;
 