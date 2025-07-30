namespace Diet.Domain.Contract.DTOs.RecommendationDisease_WhiteList
{
    public record GetItemRecommendationDisease_WhiteListDto(Guid Id, Guid RecommendationId, Guid DiseaseId);

    public record CreateRecommendationDisease_WhiteListDto(Guid RecommendationId, Guid DiseaseId);
    public record UpdateRecommendationDisease_WhiteListDto(Guid Id, Guid RecommendationId, Guid DiseaseId);
    public record DeleteRecommendationDisease_WhiteListDto(Guid Id);
    public record GetRecommendationDisease_WhiteListDto(Guid Id);
    public record GetAllRecommendationDisease_WhiteListDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
