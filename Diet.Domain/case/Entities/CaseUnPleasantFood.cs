using Diet.Domain.common;
using Diet.Domain.food.Entities;

namespace Diet.Domain.@case.Entities;

public sealed class CaseUnPleasantFood : BaseEntity
{
    public Guid FoodId { get; private set; }
    public Food Food { get; private set; }
    public Guid CaseId { get; private set; }
    public Case.Case Case { get; private set; }

    private CaseUnPleasantFood() { }
}