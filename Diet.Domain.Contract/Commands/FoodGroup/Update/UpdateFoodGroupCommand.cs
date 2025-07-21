

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateFoodGroupCommand(Guid Id,string Title) : ICommand;
 