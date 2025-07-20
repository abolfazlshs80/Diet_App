using Diet.Domain.common;

namespace Diet.Domain.food.Entities;
/// <summary>
/// غذا
/// </summary>
public sealed class Food:BaseEntity
{
    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public double? Value { get; private set; }


    public ICollection<Case.Case> Case { get; set; }
    public ICollection<Food_Food_Intraction> FoodFirst { get; set; }
    public ICollection<Food_Food_Intraction> FoodSecond { get; set; }
    private Food() { }

    ////public virtual ICollection<FoodCategory>? Categories { get; set; }
    //public  ICollection<UnPleasandFood>? UnPleasandFood { get; private set; }
    //public  ICollection<PleasandFood>? PleasandFood { get; private set; }
}
