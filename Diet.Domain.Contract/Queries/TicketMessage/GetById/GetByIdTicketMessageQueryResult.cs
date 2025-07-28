using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.TicketMessage.GetById;

public record GetByIdTicketMessageQueryResult(Guid Id, string TextMessage, string FileName, Guid TicketId, Guid FromId) : IQueryResult;
