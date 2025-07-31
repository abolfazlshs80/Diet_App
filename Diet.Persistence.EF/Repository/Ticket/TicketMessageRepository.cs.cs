using Diet.Domain.Contract.DTOs.TicketMessage;
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

    public async Task<GetItemTicketMessageDto> ByIdDtoAsync(Guid Id)
    {
        var res = await (from d in _dbContext.TicketMessage
                         where d.Id == Id
                         select new GetItemTicketMessageDto(d.Id, d.TextMessage, d.FileName, d.TicketId, d.FromId)
         ).AsNoTracking().FirstOrDefaultAsync();
        return res!;

    }

    public async Task AddAsync(TicketMessage ticketMessage)
    {
        await _dbContext.TicketMessage.AddAsync(ticketMessage);
    }

    public void Update(TicketMessage ticketMessage)
    {
        _dbContext.Update(ticketMessage);
    }

    public void Delete(TicketMessage ticketMessage)
    {
        _dbContext.Remove(ticketMessage);
    }

    public async Task<List<GetItemTicketMessageDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0)
    {
        var res = await (from d in _dbContext.TicketMessage
                         select new GetItemTicketMessageDto(d.Id, d.TextMessage, d.FileName, d.TicketId, d.FromId))
             .Skip(pageNumber * pageCount)
             .Take(pageCount)
             .AsNoTracking()
             .ToListAsync();
        return res!;

    }
}

