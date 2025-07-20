using Diet.Domain.common;

namespace Diet.Domain.sport;

public sealed class Sport: BaseEntity
{

    private Sport() { }

    public string Name { get; set; }
    public int Low { get; set; }
    public int Medium { get; set; }
    public int High { get; set; }
    public ICollection<Case.Case> Case { get; set; }

}
