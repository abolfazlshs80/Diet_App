using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.disease;
using Diet.Domain.user;
using ErrorOr;

namespace Diet.Domain.caseDrug;

public sealed class CaseDrug : BaseEntity
{
    private CaseDrug() { }

    private CaseDrug(Guid id, Guid caseId, Guid drugId) { Id = id; CaseId = caseId; DrugId = drugId; }
    public Guid CaseId { get; private set; }
    public Diet.Domain.Case.Case Case { get; private set; }

    public Guid DrugId { get; private set; }
    public drug.Drug Drug { get; private set; }


    public static ErrorOr<CaseDrug> Create(CreateCaseDrugCommand command)
    {

        return new CaseDrug(Guid.NewGuid(), command.CaseId, command.DrugId);


    }

    public static ErrorOr<CaseDrug> Update(CaseDrug CaseDisease, UpdateCaseDrugCommand command)
    {
        return new CaseDrug(CaseDisease.Id, command.CaseId, command.DrugId);


    }
}