using Diet.Domain.common;
using Diet.Domain.supplement.Entities;

namespace Diet.Domain.lifeCourse;

public class LifeCourse: BaseEntity
{
    private LifeCourse()
    {
        
    }
    public string Title { get;private set; }
    public Guid ParrentId { get; private set; }

    public ICollection<SupplementLifeCourse> SupplementLifeCourse { get; private set; }

}
