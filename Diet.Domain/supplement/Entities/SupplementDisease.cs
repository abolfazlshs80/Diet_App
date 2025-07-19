using Diet.Domain.common;
using Diet.Domain.disease;

namespace Diet.Domain.supplement.Entities;
/// <summary>
///   نگهدارنده مکمل‌های مجاز برای بیماری‌های خاص است.
/// </summary>
public sealed class SupplementDisease_WhiteList:BaseEntity
{
    private SupplementDisease_WhiteList() { }

    public Guid SupplementId { get; private set; }

    public  Supplement Supplement { get; private set; }

    public Guid DiseaseId { get; private set; }
    
    public  Disease Disease { get; private set; }
}
