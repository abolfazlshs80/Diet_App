using Dient.Domain.common;

namespace Diet.Domain.supplement;

public class SupplementGroup: BaseEntity
{
    private SupplementGroup() { }
    public string Title { get; set; }
    public virtual ICollection<Supplement> Supplement { get; private set; }
}
