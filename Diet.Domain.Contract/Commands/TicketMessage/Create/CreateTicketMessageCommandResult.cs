using Diet.Domain.Contract.Commands.TicketMessage.Create;
using Order.Framework.Core.Bus;

public record CreateTicketMessageCommandResult(string state, string message) : ICommandResult;
