

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateCaseFoodStuffAllergyCommand(  Guid CaseId, Guid FoodStuffId) : ICommand;
 