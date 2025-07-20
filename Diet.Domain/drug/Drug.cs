using Diet.Domain.Case;
using Diet.Domain.common;
using Diet.Domain.disease;
using Diet.Domain.food.Entities;

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

    public ICollection<CaseDrug> CaseDrug { get; set; }
    public ICollection<Food_Drug_Intraction> Food_Drug_Intraction { get; set; }


}
