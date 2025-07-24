using Diet.Domain.common;
using Diet.Domain.user;

namespace Diet.Domain.Case;

public sealed class CaseDrug : BaseEntity
{
    private CaseDrug() { }
    public Guid CaseId { get; private set; }
    public Case Case { get; private set; }

    public Guid DrugId { get; private set; }
    public drug.Entities.Drug Drug { get; private set; }


}