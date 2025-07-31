using Diet.Domain.Contract.Enums;

namespace Diet.Domain.Contract.DTOs.Transactions
{
    public record GetItemTransactionsDto(Guid Id, double TotalPrice, string ZarinPalAuthority, string ZarinPalRefNum, TransactionType TransactionType);

    public record CreateTransactionsDto(double TotalPrice, string ZarinPalAuthority, string ZarinPalRefNum, TransactionType TransactionType);
    public record UpdateTransactionsDto(Guid Id, double TotalPrice, string ZarinPalAuthority, string ZarinPalRefNum, TransactionType TransactionType);
    public record DeleteTransactionsDto(Guid Id);
    public record GetTransactionsDto(Guid Id);
    public record GetAllTransactionsDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
