using Diet.Domain.@case.Entities;
using Diet.Domain.Case;
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
    public Guid FoodGroupId { get; private set; }
    public FoodGroup FoodGroup { get; private set; }


    public ICollection<Food_Food_Intraction> FoodFirst { get; set; }
    public ICollection<Food_Food_Intraction> FoodSecond { get; set; }
    public ICollection<CasePleasantFood> CasePleasantFood { get; set; }
    public ICollection<CaseUnPleasantFood> CaseUnPleasantFood { get; set; }
    public ICollection<Food_Drug_Intraction> Food_Drug_Intraction { get; set; }
    public ICollection<CaseFoodStuffAllergy> CaseFoodStuffAllergy { get; private set; }//
    private Food() { }

}
