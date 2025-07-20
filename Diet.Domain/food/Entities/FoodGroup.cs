using Diet.Domain.common;
using Diet.Domain.supplement;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Domain.food.Entities;

public sealed class FoodGroup : BaseEntity
{
    public string Title { get; private set; }

    public ICollection<Food> Food { get;private set; }

    private FoodGroup(){}
}
