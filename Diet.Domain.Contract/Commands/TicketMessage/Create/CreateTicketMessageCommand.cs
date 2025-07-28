using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.TicketMessage.Create;

public record CreateTicketMessageCommand(string TextMessage, string FileName, Guid TicketId, Guid FromId) : ICommand;
