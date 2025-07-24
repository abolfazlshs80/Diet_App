using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Recommendation.Entities;
using Diet.Domain.supplement.Entities;
using ErrorOr;

namespace Diet.Domain.durationAge.Entities;

/// <summary>
/// 
/// </summary>
public sealed class DurationAge:BaseEntity
{
    private DurationAge(Guid id, string title, string description) : base(id) { Title = title; }
    private DurationAge(string title, string description) {  Title = title; }
    public string Title { get; private set; }

    public ICollection<SupplementDurationAge> SupplementDurationAge { get; private set; }
    public ICollection<RecommendationDurationAge> RecommendationDurationAge { get; private set; }



    public static ErrorOr<DurationAge> Create(CreateDurationAgeCommand command)
    {

        var foodGroup = new DurationAge(command.Title);


        return foodGroup;
    }

    public static ErrorOr<DurationAge> Update(UpdateDurationAgeCommand command)
    {
        var foodGroup = new DurationAge(command.Id, command.Title);


        return foodGroup;
    }
}
