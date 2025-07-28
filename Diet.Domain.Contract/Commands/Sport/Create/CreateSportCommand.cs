using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Sport.Create;

public record CreateSportCommand(string Name, int Low, int Medium, int High) : ICommand;
