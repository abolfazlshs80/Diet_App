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

    private Food_Food_Intraction(Guid id, Guid foodFistId, Guid foodSecondId) { Id = id; FoodFistId = foodFistId; FoodSecondId = foodSecondId; }

    public Guid FoodFistId { get; private set; }
    public Food FoodFirst { get; private set; }
    public Guid FoodSecondId { get; private set; }
    public Food FoodSecond { get; private set; }
    public static ErrorOr<Food_Food_Intraction> Create(CreateFoodFoodIntractionCommand command)
    {

        return new Food_Food_Intraction(Guid.NewGuid(), command.FoodFistId, command.FoodSecondId);


    }

    public static ErrorOr<Food_Food_Intraction> Update(Food_Food_Intraction food_Food_Intraction,UpdateFoodFoodIntractionCommand command)
    {
        return new Food_Food_Intraction(food_Food_Intraction.Id, command.FoodFistId, command.FoodSecondId);

    }
}
