using Diet.Domain.caseFoodStuffAllergy;
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
    private FoodStuff()
    {
        
    }
    private FoodStuff(Guid id, string title) { Id = id; Title = title; }
    public string Title { get; private set; }

    public ICollection<CaseFoodStuffAllergy> CaseFoodStuffAllergy { get; private set; }//

    public static ErrorOr<FoodStuff> Create(CreateFoodStuffCommand command)
    {

        return new FoodStuff(Guid.NewGuid(), command.Title);


    }

    public static ErrorOr<FoodStuff> Update(FoodStuff foodStuff,UpdateFoodStuffCommand command)
    {
        return new FoodStuff(foodStuff.Id, command.Title);


    }


}
