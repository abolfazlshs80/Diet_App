using Diet.Domain.caseDisease;
using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.recommendationDisease_WhiteList;
using Diet.Domain.supplementDisease_WhiteList;
using ErrorOr;

namespace Diet.Domain.disease;


/// <summary>
/// بیماری
/// </summary>
public sealed class Disease : BaseEntity
{
    private Disease() { }

    private Disease(Guid id, string title, Guid parentId)
    {
        Id = id;
        ParentId = parentId;
        Title = title;
    }
    public string Title { get; private set; }
    public Guid? ParentId { get; private set; }


    //public ICollection<Disease> Childeren { get; private set; }
    public ICollection<SupplementDisease_WhiteList> SupplementDisease_WhiteList { get; private set; }
    public ICollection<RecommendationDisease_WhiteList> RecommendationDisease_WhiteList { get; private set; }

    public ICollection<Domain.caseDisease.CaseDisease > CaseDisease { get; set; }


    public static ErrorOr<Disease> Create(CreateDiseaseCommand command)
    {
        return new Disease(Guid.NewGuid(), command.Title, command.ParentId);
    }

    public static ErrorOr<Disease> Update(Disease disease, UpdateDiseaseCommand command)
    {
        return new Disease(disease.Id, command.Title, command.ParentId);
    }


}
