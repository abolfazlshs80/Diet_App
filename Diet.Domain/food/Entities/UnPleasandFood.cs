using Diet.Domain.common;

namespace Diet.Domain.food.Entities;

/// <summary>
/// غذای ناخوشایند
/// </summary>
public sealed class UnPleasandFood: BaseEntity
{
    private UnPleasandFood() { }

    public Guid? FoodId { get; private set; }

    public Food? Food { get; private set; }
}
