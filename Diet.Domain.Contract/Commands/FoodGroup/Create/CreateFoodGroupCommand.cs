

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateFoodGroupCommand(string Title) : ICommand;
 