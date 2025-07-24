using Diet.Domain.common;
using Diet.Domain.lifeCourse.Entities;

namespace Diet.Domain.supplement.Entities;
/// <summary>
///   برای نگهداری اطلاعات مکمل‌های مناسب هر دوره زندگی است.
/// </summary>
public sealed class SupplementLifeCourse : BaseEntity
{
    private SupplementLifeCourse() { }

    public Guid SupplementId { get; private set; }

    public  Supplement Supplement { get; private set; }

    public Guid LifeCourseId { get; private set; }

    public  LifeCourse LifeCourse { get; private set; }
}