using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Ticket.GetById;

public record GetByIdTicketQueryResult(Guid Id, string Title, string Number, int Priority, int Status, Guid UserId) : IQueryResult;
