using Diet.Domain.Contract.Commands.TicketMessage.Update;
using Order.Framework.Core.Bus;

public record UpdateTicketMessageCommandResult(string state, string message) : ICommandResult;
