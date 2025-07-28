using Diet.Domain.Contract.Commands.Ticket.Create;
using Order.Framework.Core.Bus;

public record CreateTicketCommandResult(string state, string message) : ICommandResult;
