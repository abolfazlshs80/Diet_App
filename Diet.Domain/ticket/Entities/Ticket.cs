using Diet.Domain.Case;
using Diet.Domain.common;
using Diet.Domain.Contract.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Diet.Domain.ticket.Entities;
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

    public Guid? CaseId { get; private set; }
  
    public  Case.Case? Case { get; private set; }

    public string UserId { get; private set; }
    //[ForeignKey("UserId")]
    //public virtual ApplicationUser User { get; set; }

    public  ICollection<TicketMessage> Messages { get; private set; }

}

