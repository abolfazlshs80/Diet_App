namespace Diet.Domain.Contract.DTOs.Ticket
{
    public record GetItemTicketDto(Guid Id, string Title, string Number, int Priority, int Status, Guid UserId);

    public record CreateTicketDto(string Title, string Number, int Priority, int Status, Guid UserId);
    public record UpdateTicketDto(Guid Id, string Title, string Number, int Priority, int Status, Guid UserId);
    public record DeleteTicketDto(Guid Id);
    public record GetTicketDto(Guid Id);
    public record GetAllTicketDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
