using Diet.Domain.common;
using Diet.Domain.disease;

namespace Diet.Domain.caseDisease;

public sealed class CaseDisease : BaseEntity
{
    private CaseDisease() { }
    public Guid CaseId { get; private set; }
    public Diet.Domain.Case.Case Case { get; private set; }

    public Guid DiseaseId { get; private set; }
    public disease.Disease Disease { get; private set; }


}
