using Diet.Domain.common;
using Diet.Domain.durationAge.Entities;

namespace Diet.Domain.supplement.Entities;

/// <summary>
///   نگهدارنده مکمل‌های مجاز برای بیماری‌های خاص است.
/// </summary>
public sealed class SupplementDurationAge: BaseEntity
{
    private SupplementDurationAge() { }

    public Guid SupplementId { get; private set; }

    public Supplement Supplement { get; private set; }

    public Guid DurationAgeId { get; private set; }

    public DurationAge DurationAge { get; private set; }
}