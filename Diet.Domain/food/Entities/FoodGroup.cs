using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.supplement;
using ErrorOr;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Diet.Domain.food.Entities;

public sealed class FoodGroup : BaseEntity
{
    private FoodGroup(Guid id, string title):base(id) { Title = title; }
    private FoodGroup( string title) { Title = title; }
    
    public string Title { get; private set; }

    public ICollection<Food> Food { get;private set; }




    public static ErrorOr<FoodGroup> Create(CreateFoodGroupCommand command)
    {

        var foodGroup = new FoodGroup(command.Title);


        return foodGroup;
    }

    public static ErrorOr<FoodGroup> Update(UpdateFoodGroupCommand command)
    {
      var  foodGroup= new FoodGroup(command.Id,command.Title);


        return foodGroup;
    }
}
