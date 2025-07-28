using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Ticket.Delete;

public record DeleteTicketCommand(Guid Id) : ICommand;
