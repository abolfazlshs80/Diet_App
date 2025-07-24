using Diet.Domain.Case;
using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using ErrorOr;

namespace Diet.Domain.food.Entities;
/// <summary>
///  نمایانگر یک ماده غذایی است.
/// </summary>
public sealed class FoodStuff : BaseEntity
{
    private FoodStuff(Guid id, string title) : base(id) { Title = title; }
    private FoodStuff(string title) { Title = title; }
    public string Title { get; private set; }

    public ICollection<CaseFoodStuffAllergy> CaseFoodStuffAllergy { get; private set; }//

    public static ErrorOr<FoodStuff> Create(CreateFoodStuffCommand command)
    {

        var foodGroup = new FoodStuff(command.Title);


        return foodGroup;
    }

    public static ErrorOr<FoodStuff> Update(UpdateFoodStuffCommand command)
    {
        var foodGroup = new FoodStuff(command.Id, command.Title);


        return foodGroup;
    }


}
