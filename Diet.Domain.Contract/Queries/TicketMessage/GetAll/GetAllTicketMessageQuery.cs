using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.TicketMessage.GetAll;

public record GetAllTicketMessageQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
