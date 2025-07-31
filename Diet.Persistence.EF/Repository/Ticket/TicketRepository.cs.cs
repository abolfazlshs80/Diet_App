using Diet.Domain.Contract.DTOs.Ticket;
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
    public async Task<GetItemTicketDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.Ticket
                         where d.Id == Id
                         select new GetItemTicketDto(d.Id, d.Title, d.Number, d.Priority, d.Status, d.UserId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }
    public async Task AddAsync(Diet.Domain.ticket.Ticket ticket)
    {
        await _dbContext.Ticket.AddAsync(ticket);
    }

    public void Update(Diet.Domain.ticket.Ticket ticket)
    {
        _dbContext.Update(ticket);
    }

    public void Delete(Diet.Domain.ticket.Ticket ticket)
    {
        _dbContext.Remove(ticket);
    }

    public async Task<List<GetItemTicketDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.Ticket
                         select new GetItemTicketDto(d.Id, d.Title, d.Number, d.Priority, d.Status, d.UserId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
    public async Task<bool> IsExists(Guid id)
    {
        return await _dbContext.Ticket.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
