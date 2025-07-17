using Diet.Domain.common;

namespace Diet.Domain.food.Entities;

public class Food:BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public double? Value { get; set; }
    private Food() { }
}
