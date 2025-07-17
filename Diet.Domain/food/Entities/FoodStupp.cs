using Diet.Domain.common;

namespace Diet.Domain.food.Entities;

public class FoodStupp : BaseEntity
{
    public string Title { get; set; }

    private FoodStupp() { }
}
