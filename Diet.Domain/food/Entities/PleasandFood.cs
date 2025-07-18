using Diet.Domain.common;

namespace Diet.Domain.food.Entities;

/// <summary>
/// غذای خوشایند
/// </summary>
public sealed class PleasandFood : BaseEntity
{
    public Guid? FoodId { get; private set; }

    public Food? Food { get; private set; }
    private PleasandFood() { }
}