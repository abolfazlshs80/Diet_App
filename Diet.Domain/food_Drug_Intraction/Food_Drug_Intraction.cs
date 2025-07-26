using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.user;
using ErrorOr;

namespace Diet.Domain.food.Entities;
/// <summary>
/// این مدل مسئول شناسایی و
/// مدیریت تداخلات احتمالی بین غذاها و داروهاست.
/// </summary>
public sealed class Food_Drug_Intraction : BaseEntity
{
    private Food_Drug_Intraction()
    {
        
    }
    private Food_Drug_Intraction(Guid id, Guid foodId, Guid drugId) { Id = id; FoodId = foodId; DrugId = drugId; }

    public Guid FoodId { get; private set; }
    public Food Food { get; private set; }

    public Guid DrugId { get; private set; }
    public drug.Entities.Drug Drug { get; private set; }
    public static ErrorOr<Food_Drug_Intraction> Create(CreateFoodDrugIntractionCommand command)
    {

        return new Food_Drug_Intraction(Guid.NewGuid(), command.FoodId,command.DrugId);


    }

    public static ErrorOr<Food_Drug_Intraction> Update(Food_Drug_Intraction food_Drug_Intraction,UpdateFoodDrugIntractionCommand command)
    {
        return new Food_Drug_Intraction(food_Drug_Intraction.Id, command.FoodId, command.DrugId);


    }

}
