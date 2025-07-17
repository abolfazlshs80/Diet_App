using Diet.Domain.common;
using Diet.Domain.disease;

namespace Diet.Domain.supplement.Entities;

public class SupplementDisease_WhiteList:BaseEntity
{
    private SupplementDisease_WhiteList() { }

    public Guid SupplementId { get; private set; }

    public virtual Supplement Supplement { get; set; }

    public Guid DiseaseId { get; private set; }
    
    public virtual Disease Disease { get; set; }
}
