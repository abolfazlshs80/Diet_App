using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Ticket.GetAll;

public record GetAllTicketQueryResult(int TotalRecords, List<GetTicketItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetTicketItem(Guid Id, string Title, string Number, int Priority, int Status, Guid UserId);
