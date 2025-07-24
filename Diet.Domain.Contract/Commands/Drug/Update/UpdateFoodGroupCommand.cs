

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateDrugCommand(Guid Id, string Title, string Description) : ICommand;
 