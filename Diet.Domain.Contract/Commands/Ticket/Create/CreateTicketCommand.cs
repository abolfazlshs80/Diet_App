using Diet.Domain.Contract.Enums;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Ticket.Create;

public record CreateTicketCommand(string Title, string Number, Priority Priority, TicketStatus Status, Guid UserId) : ICommand;
