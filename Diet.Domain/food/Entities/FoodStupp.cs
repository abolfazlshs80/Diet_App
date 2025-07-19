using Diet.Domain.common;

namespace Diet.Domain.food.Entities;
/// <summary>
///  نمایانگر یک ماده غذایی است.
/// </summary>
public sealed class FoodStupp : BaseEntity
{
    public string Title { get; private set; }

    private FoodStupp() { }
}
