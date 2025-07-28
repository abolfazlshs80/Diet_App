using Diet.Domain.ticket;
using Diet.Domain.ticket.Repository;
using Diet.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Diet.Persistence.EF.Repository.Ticket;

public class TicketRepository : ITicketRepository
{
    private readonly DietDbContext _dbContext;

    public TicketRepository(DietDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Diet.Domain.ticket.Ticket> ByIdAsync(Guid id)
    {
        return await _dbContext.Ticket.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Diet.Domain.ticket.Ticket ticket)
    {
        await _dbContext.Ticket.AddAsync(ticket);
    }

    public async Task UpdateAsync(Diet.Domain.ticket.Ticket ticket)
    {
        _dbContext.Update(ticket);
    }

    public async Task DeleteAsync(Diet.Domain.ticket.Ticket ticket)
    {
        _dbContext.Remove(ticket);
    }

    public async Task<List<     Diet.Domain.ticket.Ticket>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var result = _dbContext.Ticket.AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
            result = result.Where(_ => _.Id.ToString().Contains(searchText)); // Customize search logic

        return await result
            .Skip(pageNumber * pageCount)
            .Take(pageCount)
            .AsNoTracking()
            .ToListAsync();
    }
}
