using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.TicketMessage.Delete;

public record DeleteTicketMessageCommand(Guid Id) : ICommand;
