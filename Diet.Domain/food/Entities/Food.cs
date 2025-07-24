using Diet.Domain.@case.Entities;
using Diet.Domain.Case;
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
    public ICollection<CasePleasantFood> CasePleasantFood { get; set; }
    public ICollection<CaseUnPleasantFood> CaseUnPleasantFood { get; set; }
    public ICollection<Food_Drug_Intraction> Food_Drug_Intraction { get; set; }
    public ICollection<CaseFoodStuffAllergy> CaseFoodStuffAllergy { get; private set; }//
    private Food() { }
    
    private Food(Guid id, string title,string description, double value ,Guid foodGroupId) : base(id) { Description = description; Value = value; FoodGroupId = foodGroupId; Title = title; }
    private Food( string title, string description, double value, Guid foodGroupId) { Description = description; Value = value; FoodGroupId = foodGroupId; Title = title; }

    public static ErrorOr<Food> Create(CreateFoodCommand command)
    {

        var foodGroup = new Food(command.Title, command.Description, command.Value, command.FoodGroupId);


        return foodGroup;
    }

    public static ErrorOr<Food> Update(UpdateFoodCommand command)
    {
        var foodGroup = new Food(command.Id, command.Title,command.Description,command.Value,command.FoodGroupId);


        return foodGroup;
    }

}
