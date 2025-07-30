

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateDurationAgeCommand(Guid Id,string Title, int MinAge, int MaxAge) : ICommand;
 