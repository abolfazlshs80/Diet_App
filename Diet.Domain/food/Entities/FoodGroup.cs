using Diet.Domain.common;
using Diet.Domain.supplement;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Domain.food.Entities;

public class FoodGroup : BaseEntity
{
    public string Title { get; set; }

    private FoodGroup(){}
}
