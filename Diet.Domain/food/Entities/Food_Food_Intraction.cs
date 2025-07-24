using Diet.Domain.Case;
using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.user;
using ErrorOr;

namespace Diet.Domain.food.Entities;
/// <summary>
// این مدل وظیفه دارد
// تا تداخل‌های احتمالی بین انواع مواد غذایی را شناسایی کند.

/// </summary>
public sealed class Food_Food_Intraction : BaseEntity
{
 

    private Food_Food_Intraction() { }

    private Food_Food_Intraction(Guid id, Guid foodFistId, Guid foodSecondId) : base(id) {FoodFistId = foodFistId; FoodSecondId = foodSecondId; }

    private Food_Food_Intraction(Guid foodFistId, Guid foodSecondId) : base() { FoodFistId = foodFistId; FoodSecondId = foodSecondId; }
    public Guid FoodFistId { get; private set; }
    public Food FoodFirst { get; private set; }
    public Guid FoodSecondId { get; private set; }
    public Food FoodSecond { get; private set; }
    public static ErrorOr<Food_Food_Intraction> Create(CreateFoodFoodIntractionCommand command)
    {

        var foodGroup = new Food_Food_Intraction(command.FoodFistId, command.FoodSecondId);


        return foodGroup;
    }

    public static ErrorOr<Food_Food_Intraction> Update(UpdateFoodFoodIntractionCommand command)
    {
        var foodGroup = new Food_Food_Intraction(command.Id, command.FoodFistId, command.FoodSecondId);


        return foodGroup;
    }
}
