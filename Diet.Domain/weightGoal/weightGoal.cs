using Diet.Domain.common;
using Diet.Domain.user;

namespace Diet.Domain.weightGoal;
/// <summary>
///   برای نگهداری هدف وزن کاربر
/// </summary>
public sealed class WeightGoal : BaseEntity
{
    private WeightGoal() { }
    public string Title { get; private set; }
    public Guid ParrentId { get; private set; }


    public Guid UserId { get; private set; }
    public User User { get; private set; }
}
