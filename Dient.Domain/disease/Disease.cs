using Dient.Domain.common;
using Diet.Domain.supplement;

namespace Diet.Domain.disease;

public class Disease:BaseEntity
{
    public string Title { get;private set; }
    public Guid ParentId { get; private set; } = Guid.Empty;

    public virtual Case.Case Case { get;private set; }

    public ICollection<SupplementDisease_WhiteList> SupplementDisease_WhiteList { get; private set; }

}
