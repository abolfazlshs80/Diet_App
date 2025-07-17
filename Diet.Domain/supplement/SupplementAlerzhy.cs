using Dient.Domain.common;

namespace Diet.Domain.supplement;

public class SupplementAlerzhy : BaseEntity
{
    private SupplementAlerzhy() { }
    public string Title { get; set; }
    public virtual ICollection<Supplement> Supplement { get; private set; }
}
