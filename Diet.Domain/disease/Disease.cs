using Diet.Domain.common;
using Diet.Domain.supplement.Entities;

namespace Diet.Domain.disease;


/// <summary>
/// بیماری
/// </summary>
public sealed class Disease:BaseEntity
{
    public string Title { get;private set; }
    public Guid ParentId { get; private set; } = Guid.Empty;


    public ICollection<SupplementDisease_WhiteList> SupplementDisease_WhiteList { get; private set; }

}
