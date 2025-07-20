using Diet.Domain.common;
using Diet.Domain.supplement.Entities;

namespace Diet.Domain.lifeCourse;
/// <summary>
///   -همراه وعده - نام دوره زندگی 
///    مثلاً "مدرسه"، "امتحانات "، "کنکور"، "بارداری")
/// </summary>
public sealed class LifeCourse: BaseEntity
{
    private LifeCourse()
    {
        
    }
    public string Title { get;private set; }
    public Guid ParentId { get; private set; }

    public ICollection<SupplementLifeCourse> SupplementLifeCourse { get; private set; }

    public ICollection<Case.Case> Case { get; set; }

}
