using Diet.Domain.common;
using Diet.Domain.supplement.Entities;

namespace Diet.Domain.lifeCourse;
/// <summary>
///    نام دوره زندگی 
///    (مثلاً "کودکی"، "نوجوانی"، "بزرگسالی"، "سالمندی")
/// </summary>
public sealed class LifeCourse: BaseEntity
{
    private LifeCourse()
    {
        
    }
    public string Title { get;private set; }
    public Guid ParrentId { get; private set; }

    public ICollection<SupplementLifeCourse> SupplementLifeCourse { get; private set; }

}
