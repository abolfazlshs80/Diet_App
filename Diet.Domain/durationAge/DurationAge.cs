using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.recommendationDurationAge;
using Diet.Domain.supplement.Entities;
using ErrorOr;

namespace Diet.Domain.durationAge.Entities;

/// <summary>
/// 
/// </summary>
public sealed class DurationAge:BaseEntity
{
    private DurationAge()
    {
        
    }
    private DurationAge(Guid id, string title) { Id = id; Title = title; }
    public string Title { get; private set; }

    public ICollection<SupplementDurationAge> SupplementDurationAge { get; private set; }
    public ICollection<RecommendationDurationAge> RecommendationDurationAge { get; private set; }



    public static ErrorOr<DurationAge> Create(CreateDurationAgeCommand command)
    {

        return new DurationAge(Guid.NewGuid(),command.Title);


    }

    public static ErrorOr<DurationAge> Update(DurationAge durationAge,UpdateDurationAgeCommand command)
    {
        return new DurationAge(durationAge.Id, command.Title);


    }
}
