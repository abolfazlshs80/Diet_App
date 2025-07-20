using Diet.Domain.Case;
using Diet.Domain.common;

namespace Diet.Domain.food.Entities;
/// <summary>
// این مدل وظیفه دارد
// تا تداخل‌های احتمالی بین انواع مواد غذایی را شناسایی کند.

/// </summary>
public sealed class Food_Food_Intraction : BaseEntity
{
    public Guid FoodFistId { get; private set; }
    public Food FoodFirst { get; private set; }
    public Guid FoodSecondId { get; private set; }
    public Food FoodSecond { get; private set; }

    private Food_Food_Intraction() { }
}
