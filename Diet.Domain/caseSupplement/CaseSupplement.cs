using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.supplement.Entities;
using ErrorOr;

namespace Diet.Domain.caseSupplement;

public sealed class CaseSupplement : BaseEntity
{

    public Guid SupplementId { get; private set; }
    public Supplement Supplement { get; private set; }
    public Guid CaseId { get; private set; }
    public Diet.Domain.Case.Case Case { get; private set; }

    private CaseSupplement() { }
    private CaseSupplement(Guid id, Guid caseId, Guid supplementId)
    { Id = id; CaseId = caseId; SupplementId = supplementId; }
    public static ErrorOr<CaseSupplement> Create(CreateCaseSupplementCommand command)
    {

        return new CaseSupplement(Guid.NewGuid(), command.CaseId, command.SupplementId);


    }

    public static ErrorOr<CaseSupplement> Update(CaseSupplement CaseSupplement, UpdateCaseSupplementCommand command)
    {
        return new CaseSupplement(CaseSupplement.Id, command.CaseId, command.SupplementId);


    }
}