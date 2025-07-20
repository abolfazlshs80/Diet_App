using Diet.Domain.Case;
using Diet.Domain.common;

namespace Diet.Domain.food.Entities;
/// <summary>
///  نمایانگر یک ماده غذایی است.
/// </summary>
public sealed class FoodStuff : BaseEntity
{
    public string Title { get; private set; }

    public ICollection<CaseFoodStuffAllergy> CaseFoodStuffAllergy { get; private set; }//
    private FoodStuff() { }
}
