using Diet.Domain.common;
using Diet.Domain.Contract.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Domain.transactions;
/// <summary>
///  نمایانگر یک تراکنش مالی یا عملیاتی در سیستم
/// </summary>
public class Transactions : BaseEntity
{
    private Transactions()
    {

    }

    public double TotalPrice { get; private set; }
    public string? ZarinPalAuthority { get; private set; }
    public string? ZarinPalRefNum { get; private set; }
    public TransactionType TransactionType { get; private set; }

    ////public Guid PlanPluginId { get; set; }
    ////[ForeignKey("PlanPluginId")]
    ////public virtual PlanPlugin PlanPlugin { get; set; }
}

