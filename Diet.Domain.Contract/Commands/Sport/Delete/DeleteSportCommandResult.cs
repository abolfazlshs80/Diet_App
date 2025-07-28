using Diet.Domain.Contract.Commands.Sport.Delete;
using Order.Framework.Core.Bus;

public record DeleteSportCommandResult(string state, string message) : ICommandResult;
