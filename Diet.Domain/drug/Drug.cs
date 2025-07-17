using Diet.Domain.Case;
using Diet.Domain.disease;

namespace Diet.Domain.user;

/// <summary>
/// دارو
/// </summary>
public sealed class Drug 
{

    private Drug()
    {
        
    }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public Guid? CaseId { get; private set; }

    public  Case.Case? Case { get; private set; }

}
