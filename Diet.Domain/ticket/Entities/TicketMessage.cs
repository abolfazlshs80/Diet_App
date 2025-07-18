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

    public string TextMessage { get; set; }
    public string FileName { get; set; }

    public Guid TicketId { get; set; }

    public  Ticket Ticket { get; set; }

    public Guid FromId { get; set; }

    public  User FromUser { get; set; }
}

