using Diet.Domain.Case;
using Diet.Domain.common;
using Diet.Domain.Contract.Enums;
using ErrorOr;
using System.ComponentModel.DataAnnotations.Schema;
using Diet.Domain.Contract.Commands.Transactions.Create;
using Diet.Domain.Contract.Commands.Transactions.Update;

namespace Diet.Domain.transactions;
/// <summary>
///  نمایانگر یک تراکنش مالی یا عملیاتی در سیستم
/// </summary>
public sealed class Transactions : BaseEntity
{
    private Transactions()
    {

    }

    public double TotalPrice { get; private set; }
    public string? ZarinPalAuthority { get; private set; }
    public string? ZarinPalRefNum { get; private set; }
    public TransactionType TransactionType { get; private set; }
    public ICollection<Case.Case> Case { get; private set; }


    private Transactions(Guid id, double totalPrice, string zarinPalAuthority, string zarinPalRefNum, TransactionType transactionType)
    {
        Id = id;
        TotalPrice = totalPrice;
        ZarinPalAuthority = zarinPalAuthority;
        ZarinPalRefNum = zarinPalRefNum;
        TransactionType = transactionType;
    }

    public static ErrorOr<Diet.Domain.transactions.Transactions> Create(CreateTransactionsCommand command)
    {
        return new Transactions(
            Guid.NewGuid(),
            command.TotalPrice,
            command.ZarinPalAuthority,
            command.ZarinPalRefNum,
            command.TransactionType
        );
    }

    public static ErrorOr<Diet.Domain.transactions.Transactions> Update(Diet.Domain.transactions.Transactions existing, UpdateTransactionsCommand command)
    {
        return new Transactions(
            existing.Id,
            command.TotalPrice,
            command.ZarinPalAuthority,
            command.ZarinPalRefNum,
            command.TransactionType
        );
    }
}

