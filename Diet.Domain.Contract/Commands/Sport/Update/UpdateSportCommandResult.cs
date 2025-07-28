using Diet.Domain.Contract.Commands.Sport.Update;
using Order.Framework.Core.Bus;

public record UpdateSportCommandResult(string state, string message) : ICommandResult;
