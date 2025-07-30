namespace Diet.Domain.Contract.DTOs.SupplementDisease_WhiteList
{
    public record GetItemSupplementDisease_WhiteListDto(Guid Id, Guid SupplementId, Guid DiseaseId);

    public record CreateSupplementDisease_WhiteListDto(Guid SupplementId, Guid DiseaseId);
    public record UpdateSupplementDisease_WhiteListDto(Guid Id, Guid SupplementId, Guid DiseaseId);
    public record DeleteSupplementDisease_WhiteListDto(Guid Id);
    public record GetSupplementDisease_WhiteListDto(Guid Id);
    public record GetAllSupplementDisease_WhiteListDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
