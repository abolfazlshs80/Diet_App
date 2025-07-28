using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.TicketMessage.GetById;

public record GetByIdTicketMessageQuery(Guid Id) : IQuery;
