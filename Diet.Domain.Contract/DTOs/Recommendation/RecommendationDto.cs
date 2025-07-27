namespace Diet.Domain.Contract.DTOs.Recommendation
{
    public record CreateRecommendationDto(string Title, string EnglishTitle, string Description, string HowToUse);
    public record UpdateRecommendationDto(Guid Id, string Title, string EnglishTitle, string Description, string HowToUse);
    public record DeleteRecommendationDto(Guid Id);
    public record GetRecommendationDto(Guid Id);
    public record GetAllRecommendationDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
