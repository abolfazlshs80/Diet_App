using Diet.Domain.Contract.Commands.Ticket.Update;
using Order.Framework.Core.Bus;

public record UpdateTicketCommandResult(string state, string message) : ICommandResult;
