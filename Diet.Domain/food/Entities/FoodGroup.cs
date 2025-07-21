using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.supplement;
using ErrorOr;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Diet.Domain.food.Entities;

public sealed class FoodGroup : BaseEntity
{
    private FoodGroup(string title):base() { Title = title; }
    public string Title { get; private set; }

    public ICollection<Food> Food { get;private set; }




    public static ErrorOr<FoodGroup> Create(CreateFoodGroupCommand command)
    {
        var foodGroupId = Guid.NewGuid().ToString();

        var foodGroup = new FoodGroup( command.Title);


        return foodGroup;
    }
}
