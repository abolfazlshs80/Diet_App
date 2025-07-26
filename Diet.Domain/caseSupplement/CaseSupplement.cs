using Diet.Domain.common;
using Diet.Domain.supplement.Entities;

namespace Diet.Domain.caseSupplement;

public sealed class CaseSupplement:BaseEntity
{

    public Guid SupplementId{ get; private set; }
    public Supplement Supplement { get; private set; }
    public Guid CaseId { get; private set; }
    public Diet.Domain.Case.Case Case { get; private set; }
}