using Diet.Domain.Contract.Commands.Sport.Create;
using Order.Framework.Core.Bus;

public record CreateSportCommandResult(string state, string message) : ICommandResult;
