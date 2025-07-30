namespace Diet.Domain.Contract.DTOs.Sport
{
    public record GetItemSportDto(Guid Id, string Name, int Low, int Medium, int High);

    public record CreateSportDto(string Name, int Low, int Medium, int High);
    public record UpdateSportDto(Guid Id, string Name, int Low, int Medium, int High);
    public record DeleteSportDto(Guid Id);
    public record GetSportDto(Guid Id);
    public record GetAllSportDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
