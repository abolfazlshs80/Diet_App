using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Recommendation.Create;
using Diet.Domain.Contract.Commands.Recommendation.Update;
using Diet.Domain.recommendationDisease_WhiteList;
using Diet.Domain.recommendationDurationAge;
using Diet.Domain.recommendationLifeCourse;
using ErrorOr;

namespace Diet.Domain.recommendation;
/// <summary>
///    نمایانگر یک مکمل غذایی است.
/// </summary>
public sealed class Recommendation:BaseEntity
{
    private Recommendation() { }
    public string? Title { get;private set; }
    public string? EnglishTitle { get; private set; }
    public string? Description { get; private set; }
    public string? HowToUse { get; private set; }

    public ICollection< RecommendationDisease_WhiteList> RecommendationDisease_WhiteList  { get; private set; }
    public ICollection<RecommendationDurationAge> RecommendationDurationAge { get; private set; }
    public ICollection<RecommendationLifeCourse> RecommendationLifeCourse { get; private set; }




    private Recommendation(Guid id, string title, string englishTitle, string description, string howToUse)
    {
        Id = id;
        Title = title;
        EnglishTitle = englishTitle;
        Description = description;
        HowToUse = howToUse;
    }

    public static ErrorOr<Recommendation> Create(CreateRecommendationCommand command)
    {
        return new Recommendation(
            Guid.NewGuid(),
            command.Title,
            command.EnglishTitle,
            command.Description,
            command.HowToUse
        );
    }

    public static ErrorOr<Recommendation> Update(Recommendation existing, UpdateRecommendationCommand command)
    {
        return new Recommendation(
            existing.Id,
            command.Title,
            command.EnglishTitle,
            command.Description,
            command.HowToUse
        );
    }
}
