

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateCaseFoodStuffAllergyCommand(Guid Id, Guid CaseId, Guid FoodStuffId) : ICommand;
 