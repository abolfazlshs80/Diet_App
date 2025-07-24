

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateDrugCommand(string Title, string Description) : ICommand;
 