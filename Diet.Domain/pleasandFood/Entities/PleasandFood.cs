using Diet.Domain.common;
using Diet.Domain.food.Entities;

namespace Diet.Domain.pleasandFood.Entities;

/// <summary>
/// غذای خوشایند
/// </summary>
public sealed class PleasandFood : BaseEntity
{
    public Guid? FoodId { get; private set; }

    public Food? Food { get; private set; }
    private PleasandFood() { }
}