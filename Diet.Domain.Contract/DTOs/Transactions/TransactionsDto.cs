namespace Diet.Domain.Contract.DTOs.Transactions
{
    public record CreateTransactionsDto(float TotalPrice, string ZarinPalAuthority, string ZarinPalRefNum, int TransactionType);
    public record UpdateTransactionsDto(Guid Id, float TotalPrice, string ZarinPalAuthority, string ZarinPalRefNum, int TransactionType);
    public record DeleteTransactionsDto(Guid Id);
    public record GetTransactionsDto(Guid Id);
    public record GetAllTransactionsDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
