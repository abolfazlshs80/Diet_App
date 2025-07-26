using Diet.Domain.common;
using Diet.Domain.food.Entities;

namespace Diet.Domain.casePleasantFood;

public sealed class CasePleasantFood : BaseEntity
{
    public Guid FoodId { get; private set; }
    public food.Entities.Food Food { get; private set; }
    public Guid CaseId { get; private set; }
    public Case.Case Case { get; private set; }

    private CasePleasantFood() { }
}
