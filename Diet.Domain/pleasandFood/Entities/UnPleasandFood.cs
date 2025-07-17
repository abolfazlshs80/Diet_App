using Diet.Domain.common;
using Diet.Domain.food.Entities;

namespace Diet.Domain.pleasandFood.Entities;

/// <summary>
/// غذای ناخوشایند
/// </summary>
public sealed class UnPleasandFood: BaseEntity
{
    private UnPleasandFood() { }

    public Guid? FoodId { get; private set; }

    public Food? Food { get; private set; }
}
