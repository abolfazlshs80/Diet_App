using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using ErrorOr;

namespace Diet.Domain.caseUnPleasantFood;

public sealed class CaseUnPleasantFood : BaseEntity
{
    public Guid FoodId { get; private set; }
    public food.Entities.Food Food { get; private set; }
    public Guid CaseId { get; private set; }
    public Case.Case Case { get; private set; }

    private CaseUnPleasantFood() { }

    private CaseUnPleasantFood
(Guid id, Guid caseId, Guid foodId)
    { Id = id; CaseId = caseId; FoodId = foodId; }
    public static ErrorOr<CaseUnPleasantFood> Create(CreateCaseUnPleasantFoodCommand command)
    {

        return new CaseUnPleasantFood(Guid.NewGuid(), command.CaseId, command.FoodId);


    }

    public static ErrorOr<CaseUnPleasantFood> Update(CaseUnPleasantFood CaseUnPleasantFood, UpdateCaseUnPleasantFoodCommand command)
    {
        return new CaseUnPleasantFood(CaseUnPleasantFood.Id, command.CaseId, command.FoodId);


    }
}