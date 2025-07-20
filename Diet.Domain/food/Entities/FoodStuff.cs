using Diet.Domain.common;

namespace Diet.Domain.food.Entities;
/// <summary>
///  نمایانگر یک ماده غذایی است.
/// </summary>
public sealed class FoodStuff : BaseEntity
{
    public string Title { get; private set; }

    public ICollection<Case.Case> Case { get; set; }
    private FoodStuff() { }
}
