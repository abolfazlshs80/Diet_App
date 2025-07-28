using Diet.Domain.Contract.Commands.TicketMessage.Delete;
using Order.Framework.Core.Bus;

public record DeleteTicketMessageCommandResult(string state, string message) : ICommandResult;
