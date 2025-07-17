using Diet.Domain.common;

namespace Diet.Domain.food.Entities;
/// <summary>
// این مدل وظیفه دارد
// تا تداخل‌های احتمالی بین انواع مواد غذایی را شناسایی کند.

/// </summary>
public sealed class Food_Food_Intraction : BaseEntity
{
    public Guid FoodId { get; set; }
    public Food Food { get; set; }

    private Food_Food_Intraction() { }
}
