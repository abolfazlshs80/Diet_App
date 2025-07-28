using Diet.Domain.common;
using Diet.Domain.ticket;
using Diet.Domain.user;
using ErrorOr;
using System.ComponentModel.DataAnnotations.Schema;
using Diet.Domain.Contract.Commands.TicketMessage.Create;
using Diet.Domain.Contract.Commands.TicketMessage.Update;

namespace Diet.Domain.ticketMessage;
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


    private TicketMessage(Guid id, string textMessage, string fileName, Guid ticketId, Guid fromId)
    {
        Id = id;
        TextMessage = textMessage;
        FileName = fileName;
        TicketId = ticketId;
        FromId = fromId;
    }

    public static ErrorOr<Diet.Domain.ticketMessage.TicketMessage> Create(CreateTicketMessageCommand command)
    {
        return new TicketMessage(
            Guid.NewGuid(),
            command.TextMessage,
            command.FileName,
            command.TicketId,
            command.FromId
        );
    }

    public static ErrorOr<Diet.Domain.ticketMessage.TicketMessage> Update(Diet.Domain.ticketMessage.TicketMessage existing, UpdateTicketMessageCommand command)
    {
        return new TicketMessage(
            existing.Id,
            command.TextMessage,
            command.FileName,
            command.TicketId,
            command.FromId
        );
    }
}

