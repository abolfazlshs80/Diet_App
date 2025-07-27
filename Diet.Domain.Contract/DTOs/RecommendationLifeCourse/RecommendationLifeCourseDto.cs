namespace Diet.Domain.Contract.DTOs.RecommendationLifeCourse
{
    public record CreateRecommendationLifeCourseDto(Guid RecommendationId, Guid LifeCourseId);
    public record UpdateRecommendationLifeCourseDto(Guid Id, Guid RecommendationId, Guid LifeCourseId);
    public record DeleteRecommendationLifeCourseDto(Guid Id);
    public record GetRecommendationLifeCourseDto(Guid Id);
    public record GetAllRecommendationLifeCourseDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
