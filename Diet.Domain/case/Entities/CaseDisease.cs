using Diet.Domain.common;
using Diet.Domain.disease;

namespace Diet.Domain.Case;

public sealed class CaseDisease : BaseEntity
{
    private CaseDisease() { }
    public Guid CaseId { get; private set; }
    public Case Case { get; private set; }

    public Guid DiseaseId { get; private set; }
    public Disease Disease { get; private set; }


}
