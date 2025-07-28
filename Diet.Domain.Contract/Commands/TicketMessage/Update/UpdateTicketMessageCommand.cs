using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.TicketMessage.Update;

public record UpdateTicketMessageCommand(Guid Id, string TextMessage, string FileName, Guid TicketId, Guid FromId) : ICommand;
