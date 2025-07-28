using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Sport.Delete;

public record DeleteSportCommand(Guid Id) : ICommand;
