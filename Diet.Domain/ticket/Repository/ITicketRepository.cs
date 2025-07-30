using Diet.Domain.Contract.DTOs.Ticket;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.ticket.Repository
{
    public interface ITicketRepository : IRepository
    {
        Task<List<GetItemTicketDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.ticket.Ticket> ByIdAsync(Guid id);
        Task<GetItemTicketDto> ByIdDtoAsync(Guid id);
        Task<bool> IsExists(Guid id);
        Task AddAsync(Diet.Domain.ticket.Ticket ticket);
        Task UpdateAsync(Diet.Domain.ticket.Ticket ticket);
        Task DeleteAsync(Diet.Domain.ticket.Ticket ticket);
    }
}
