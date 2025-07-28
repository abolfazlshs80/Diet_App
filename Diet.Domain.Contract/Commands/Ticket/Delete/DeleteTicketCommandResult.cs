using Diet.Domain.Contract.Commands.Ticket.Delete;
using Order.Framework.Core.Bus;

public record DeleteTicketCommandResult(string state, string message) : ICommandResult;
