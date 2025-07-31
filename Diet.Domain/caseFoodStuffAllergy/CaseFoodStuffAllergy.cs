using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;

using Diet.Domain.food.Entities;
using ErrorOr;

namespace Diet.Domain.caseFoodStuffAllergy;

public sealed class CaseFoodStuffAllergy : BaseEntity
{
    private CaseFoodStuffAllergy(Guid id, Guid caseId, Guid foodStuffId) { Id = id; CaseId = caseId; FoodStuffId = foodStuffId; }
    private CaseFoodStuffAllergy() { }
    public Guid FoodStuffId { get; private set; }
    public food.Entities.FoodStuff FoodStuff { get; private set; }

    public Guid CaseId { get; private set; }
    public Diet.Domain.Case.Case Case { get; private set; }
    public static ErrorOr<CaseFoodStuffAllergy> Create(CreateCaseFoodStuffAllergyCommand command)
    {

        return new CaseFoodStuffAllergy(Guid.NewGuid(), command.CaseId, command.FoodStuffId);


    }

    public static ErrorOr<CaseFoodStuffAllergy> Update(CaseFoodStuffAllergy CaseDisease, UpdateCaseFoodStuffAllergyCommand command)
    {
        return new CaseFoodStuffAllergy(CaseDisease.Id, command.CaseId, command.FoodStuffId);


    }

}