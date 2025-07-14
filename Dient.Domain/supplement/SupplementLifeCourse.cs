using Dient.Domain.common;
using Diet.Domain.lifeCourse;

namespace Diet.Domain.supplement;

public class SupplementLifeCourse : BaseEntity
{
    private SupplementLifeCourse() { }

    public Guid SupplementId { get; private set; }

    public virtual Supplement Supplement { get; set; }

    public Guid LifeCourseId { get; private set; }

    public virtual LifeCourse LifeCourse { get; set; }
}