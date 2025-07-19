using Diet.Domain.common;
using Diet.Domain.user;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Domain.ticket.Entities;
/// <summary>
///  پیام‌ها یا گفتگوهای مرتبط با یک تیکت
/// </summary>


public sealed class TicketMessage : BaseEntity
{
    private TicketMessage()
    {
        
    }

    public string TextMessage { get; private set; }
    public string FileName { get; private set; }

    public Guid TicketId { get; private set; }

    public  Ticket Ticket { get; private set; }

    public Guid FromId { get; private set; }

    public  User FromUser { get; private set; }
}

