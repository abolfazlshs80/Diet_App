

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Delete;

public record DeleteCasePleasantFoodCommand(Guid Id) : ICommand;
 