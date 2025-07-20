using Diet.Domain.Case;
using Diet.Domain.common;
using Diet.Domain.disease;

namespace Diet.Domain.user;

/// <summary>
/// دارو
/// </summary>
public sealed class Drug :BaseEntity
{

    private Drug()
    {
        
    }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public ICollection<Case.Case> Case { get; set; }


}
