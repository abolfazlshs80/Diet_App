using Diet.Framework.Core.Interface;
namespace Diet.Domain.ticketMessage.Repository
{
    public interface ITicketMessageRepository : IRepository
    {
        Task<List<Diet.Domain.ticketMessage.TicketMessage>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.ticketMessage.TicketMessage> ByIdAsync(Guid id);

        Task AddAsync(Diet.Domain.ticketMessage.TicketMessage ticketMessage);
        Task UpdateAsync(Diet.Domain.ticketMessage.TicketMessage ticketMessage);
        Task DeleteAsync(Diet.Domain.ticketMessage.TicketMessage ticketMessage);
    }
}
