

using Dient.Domain.common;

namespace Diet.Domain.food;

public class Food:BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public double? Value { get; set; }
    private Food() { }
}
