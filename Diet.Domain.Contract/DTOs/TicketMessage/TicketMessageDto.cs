namespace Diet.Domain.Contract.DTOs.TicketMessage
{
  public record GetItemTicketMessageDto(Guid Id, string TextMessage, string FileName, Guid TicketId, Guid FromId);

    public record CreateTicketMessageDto(string TextMessage, string FileName, Guid TicketId, Guid FromId);
    public record UpdateTicketMessageDto(Guid Id, string TextMessage, string FileName, Guid TicketId, Guid FromId);
    public record DeleteTicketMessageDto(Guid Id);
    public record GetTicketMessageDto(Guid Id);
    public record GetAllTicketMessageDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
