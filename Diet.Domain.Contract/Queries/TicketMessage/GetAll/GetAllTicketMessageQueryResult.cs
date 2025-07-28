using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.TicketMessage.GetAll;

public record GetAllTicketMessageQueryResult(int TotalRecords, List<GetTicketMessageItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetTicketMessageItem(Guid Id, string TextMessage, string FileName, Guid TicketId, Guid FromId);
