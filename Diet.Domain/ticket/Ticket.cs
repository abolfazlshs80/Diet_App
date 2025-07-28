using Diet.Domain.Case;
using Diet.Domain.common;
using Diet.Domain.Contract.Enums;
using Diet.Domain.user;
using ErrorOr;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Diet.Domain.Contract.Commands.Ticket.Create;
using Diet.Domain.Contract.Commands.Ticket.Update;
using Diet.Domain.ticketMessage;

namespace Diet.Domain.ticket;
/// <summary>
/// رای ثبت و مدیریت درخواست‌ها یا مشکلات کاربران
/// </summary>

public sealed class Ticket:BaseEntity
{
    private Ticket()
    {

    }

    public string Title { get; private set; }
    public string Number { get; private set; }
    public Priority Priority { get; private set; }
    public TicketStatus Status { get; private   set; }


    public Guid UserId { get; private set; }

    public  User User { get;private set; }

    public  ICollection<TicketMessage> Messages { get; private set; }
    private Ticket(Guid id, string title, string number, Priority priority, TicketStatus status, Guid userId)
    {
        Id = id;
        Title = title;
        Number = number;
        Priority = priority;
        Status = status;
        UserId = userId;
    }

    public static ErrorOr<Ticket> Create(CreateTicketCommand command)
    {
        return new Ticket(
            Guid.NewGuid(),
            command.Title,
            command.Number,
           command.Priority,
         command.Status,
            command.UserId
        );
    }

    public static ErrorOr<Ticket> Update(Ticket existing, UpdateTicketCommand command)
    {
        return new Ticket(
            existing.Id,
            command.Title,
            command.Number,
            command.Priority,
            command.Status,
            command.UserId
        );
    }

}

