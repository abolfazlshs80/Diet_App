using Diet.Domain.common;
using Diet.Domain.food.Entities;

namespace Diet.Domain.Case;

public sealed class CaseFoodStuffAllergy : BaseEntity
{
    private CaseFoodStuffAllergy() { }
    public Guid FoodStuffId { get; private set; }
    public FoodStuff FoodStuff { get; private set; }

    public Guid CaseId { get; private set; }
    public Case Case { get; private set; }


}