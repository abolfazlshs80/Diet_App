using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Ticket.GetById;

public record GetByIdTicketQuery(Guid Id) : IQuery;
