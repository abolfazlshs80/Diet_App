using Diet.Domain.common;
using Diet.Domain.supplement.Entities;

namespace Diet.Domain.Case;

public sealed class CaseSupplement:BaseEntity
{

    public Guid SupplementId{ get; private set; }
    public Supplement Supplement { get; private set; }
    public Guid CaseId { get; private set; }
    public Case Case { get; private set; }
}