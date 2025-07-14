using Dient.Domain.common;

namespace Diet.Domain.supplement;

public class Supplement:BaseEntity
{
    private Supplement() { }
    public string? Title { get;private set; }
    public string? EnglishTitle { get; private set; }
    public string? Description { get; private set; }
    public string? HowToUse { get; private set; }

    public Guid SupplementGroupId { get; private set; }
    public virtual SupplementGroup SupplementGroup { get; private set; }
    public ICollection< SupplementDisease_WhiteList> SupplementDisease_WhiteList  { get; private set; }
}
