using Diet.Domain.common;
using Diet.Domain.pleasandFood.Entities;

namespace Diet.Domain.food.Entities;
/// <summary>
/// غذا
/// </summary>
public sealed class Food:BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public double? Value { get; set; }
    private Food() { }

    //public virtual ICollection<FoodCategory>? Categories { get; set; }
    public  ICollection<UnPleasandFood>? UnPleasandFood { get; set; }
    public  ICollection<PleasandFood>? PleasandFood { get; set; }
}
