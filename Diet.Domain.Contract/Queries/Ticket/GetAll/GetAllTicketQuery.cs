using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Ticket.GetAll;

public record GetAllTicketQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
