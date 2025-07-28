using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Sport.Update;

public record UpdateSportCommand(Guid Id, string Name, int Low, int Medium, int High) : ICommand;
