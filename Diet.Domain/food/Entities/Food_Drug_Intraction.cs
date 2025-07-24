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
    private Food_Drug_Intraction(Guid id, Guid foodId, Guid drugId) : base(id) { FoodId = foodId; DrugId = drugId; }

    private Food_Drug_Intraction(Guid foodId, Guid drugId) : base() { FoodId = foodId; DrugId = drugId; }
    public Guid FoodId { get; private set; }
    public Food Food { get; private set; }

    public Guid DrugId { get; private set; }
    public Drug Drug { get; private set; }
    public static ErrorOr<Food_Drug_Intraction> Create(CreateFoodDrugIntractionCommand command)
    {

        var foodGroup = new Food_Drug_Intraction(command.FoodId,command.DrugId);


        return foodGroup;
    }

    public static ErrorOr<Food_Drug_Intraction> Update(UpdateFoodDrugIntractionCommand command)
    {
        var foodGroup = new Food_Drug_Intraction(command.Id, command.FoodId, command.DrugId);


        return foodGroup;
    }

}
