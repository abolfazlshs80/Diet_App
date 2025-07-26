using Diet.Domain.common;
using Diet.Domain.food.Entities;

namespace Diet.Domain.caseFoodStuffAllergy;

public sealed class CaseFoodStuffAllergy : BaseEntity
{
    private CaseFoodStuffAllergy() { }
    public Guid FoodStuffId { get; private set; }
    public food.Entities.FoodStuff FoodStuff { get; private set; }

    public Guid CaseId { get; private set; }
    public Diet.Domain.Case.Case Case { get; private set; }


}