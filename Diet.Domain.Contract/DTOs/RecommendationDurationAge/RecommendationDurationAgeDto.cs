namespace Diet.Domain.Contract.DTOs.RecommendationDurationAge
{
    public record CreateRecommendationDurationAgeDto(Guid RecommendationId, Guid DurationAgeId);
    public record UpdateRecommendationDurationAgeDto(Guid Id, Guid RecommendationId, Guid DurationAgeId);
    public record DeleteRecommendationDurationAgeDto(Guid Id);
    public record GetRecommendationDurationAgeDto(Guid Id);
    public record GetAllRecommendationDurationAgeDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
