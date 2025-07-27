using Diet.Domain.caseFoodStuffAllergy;
using Diet.Domain.casePleasantFood;
using Diet.Domain.caseUnPleasantFood;
using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using ErrorOr;

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
    public ICollection<casePleasantFood. CasePleasantFood> CasePleasantFood { get; set; }
    public ICollection<caseUnPleasantFood.CaseUnPleasantFood> CaseUnPleasantFood { get; set; }
    public ICollection<Food_Drug_Intraction> Food_Drug_Intraction { get; set; }
    public ICollection<caseFoodStuffAllergy.CaseFoodStuffAllergy> CaseFoodStuffAllergy { get; private set; }//
    private Food() { }
    
    private Food(Guid id, string title,string description, double value ,Guid foodGroupId) { Id = id; Description = description; Value = value; FoodGroupId = foodGroupId; Title = title; }
    
    public static ErrorOr<Food> Create(CreateFoodCommand command)
    {

        return new Food(Guid.NewGuid(),command.Title, command.Description, command.Value, command.FoodGroupId);

    }

    public static ErrorOr<Food> Update(Food food,UpdateFoodCommand command)
    {
        return new Food(food.Id, command.Title,command.Description,command.Value,command.FoodGroupId);


    }

}
