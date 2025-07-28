using Diet.Domain.ticketMessage;
using Diet.Domain.ticketMessage.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Ticket;

public class TicketMessageRepository : ITicketMessageRepository
{
    private readonly DietDbContext _dbContext;

    public TicketMessageRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TicketMessage> ByIdAsync(Guid id)
    {
        return await _dbContext.TicketMessage.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(TicketMessage ticketMessage)
    {
        await _dbContext.TicketMessage.AddAsync(ticketMessage);
    }

    public async Task UpdateAsync(TicketMessage ticketMessage)
    {
        _dbContext.Update(ticketMessage);
    }

    public async Task DeleteAsync(TicketMessage ticketMessage)
    {
        _dbContext.Remove(ticketMessage);
    }

    public async Task<List<     TicketMessage>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.TicketMessage.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
