using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.disease;
using Diet.Domain.food.Entities;
using ErrorOr;

namespace Diet.Domain.casePleasantFood;

public sealed class CasePleasantFood : BaseEntity
{
    public Guid FoodId { get; private set; }
    public food.Entities.Food Food { get; private set; }
    public Guid CaseId { get; private set; }
    public Case.Case Case { get; private set; }

    private CasePleasantFood() { }
    private CasePleasantFood
(Guid id, Guid caseId, Guid foodId)
    { Id = id; CaseId = caseId; FoodId = FoodId; }
    public static ErrorOr<CasePleasantFood> Create(CreateCasePleasantFoodCommand command)
    {

        return new CasePleasantFood(Guid.NewGuid(), command.CaseId, command.FoodId);


    }

    public static ErrorOr<CasePleasantFood> Update(CasePleasantFood CasePleasantFood, UpdateCasePleasantFoodCommand command)
    {
        return new CasePleasantFood(CasePleasantFood.Id, command.CaseId, command.FoodId);


    }
}
