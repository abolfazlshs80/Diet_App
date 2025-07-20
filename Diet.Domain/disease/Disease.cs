using Diet.Domain.Case;
using Diet.Domain.common;
using Diet.Domain.Recommendation.Entities;
using Diet.Domain.supplement.Entities;

namespace Diet.Domain.disease;


/// <summary>
/// بیماری
/// </summary>
public sealed class Disease:BaseEntity
{
    public string Title { get;private set; }
    public Guid? ParentId { get; private set; } 
    public Disease Parent { get; private set; } 




    public ICollection<Disease> Childeren { get; private set; }
    public ICollection<SupplementDisease_WhiteList> SupplementDisease_WhiteList { get; private set; }
    public ICollection<RecommendationDisease_WhiteList> RecommendationDisease_WhiteList { get; private set; }

    public ICollection<CaseDisease> CaseDisease { get; set; }

}
