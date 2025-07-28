namespace Diet.Domain.Contract.DTOs.Supplement
{
    public record CreateSupplementDto(string Title, string EnglishTitle, string Description, string HowToUse, Guid SupplementGroupId);
    public record UpdateSupplementDto(Guid Id, string Title, string EnglishTitle, string Description, string HowToUse, Guid SupplementGroupId);
    public record DeleteSupplementDto(Guid Id);
    public record GetSupplementDto(Guid Id);
    public record GetAllSupplementDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
