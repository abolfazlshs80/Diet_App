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
    private FoodGroup()
    {
        
    }
    private FoodGroup(Guid id, string title) { Id = id; Title = title; }
    private FoodGroup( string title) { Title = title; }
    
    public string Title { get; private set; }

    public ICollection<Food> Food { get;private set; }




    public static ErrorOr<FoodGroup> Create(CreateFoodGroupCommand command)
    {

        return new FoodGroup(Guid.NewGuid(), command.Title);

    }

    public static ErrorOr<FoodGroup> Update(FoodGroup foodgroup, UpdateFoodGroupCommand command)
    {
        return new FoodGroup(foodgroup.Id,command.Title);

    }
}
