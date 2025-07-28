namespace Diet.Domain.Contract.DTOs.SupplementDurationAge
{
    public record CreateSupplementDurationAgeDto(Guid SupplementId, Guid DurationAgeId);
    public record UpdateSupplementDurationAgeDto(Guid Id, Guid SupplementId, Guid DurationAgeId);
    public record DeleteSupplementDurationAgeDto(Guid Id);
    public record GetSupplementDurationAgeDto(Guid Id);
    public record GetAllSupplementDurationAgeDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
