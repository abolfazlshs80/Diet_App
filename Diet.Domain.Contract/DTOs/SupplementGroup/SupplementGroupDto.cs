namespace Diet.Domain.Contract.DTOs.SupplementGroup
{
    public record CreateSupplementGroupDto(string Title);
    public record UpdateSupplementGroupDto(Guid Id, string Title);
    public record DeleteSupplementGroupDto(Guid Id);
    public record GetSupplementGroupDto(Guid Id);
    public record GetAllSupplementGroupDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
