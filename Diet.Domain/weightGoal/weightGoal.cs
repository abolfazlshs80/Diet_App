using Diet.Domain.common;

namespace Diet.Domain.weightGoal;

public class WeightGoal : BaseEntity
{
    private WeightGoal() { }
    public string Title { get; private set; }
    public Guid ParrentId { get; private set; }
}
