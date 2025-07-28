using Diet.Domain.caseSupplement;
using Diet.Domain.common;
using ErrorOr;
using Diet.Domain.Contract.Commands.Supplement.Update;
using Diet.Domain.Contract.Commands.Supplement.Create;
using Diet.Domain.supplementDisease_WhiteList;
using Diet.Domain.supplementGroup;
using Diet.Domain.supplementDurationAge;
using Diet.Domain.supplementLifeCourse;

namespace Diet.Domain.supplement;
/// <summary>
///    نمایانگر یک مکمل غذایی است.
/// </summary>
public sealed class Supplement:BaseEntity
{
    private Supplement() { }
    public string? Title { get;private set; }
    public string? EnglishTitle { get; private set; }
    public string? Description { get; private set; }
    public string? HowToUse { get; private set; }

    public ICollection<caseSupplement.CaseSupplement> CaseSupplement { get; set; }
    public Guid SupplementGroupId { get; private set; }
    public  SupplementGroup SupplementGroup { get; private set; }
    public ICollection< SupplementDisease_WhiteList> SupplementDisease_WhiteList  { get; private set; }
    public ICollection<SupplementDurationAge> SupplementDurationAge { get; private set; }
    public ICollection<SupplementLifeCourse> SupplementLifeCourse { get; private set; }

    private Supplement(Guid id, string title, string englishTitle, string description, string howToUse, Guid supplementGroupId)
    {
        Id = id;
        Title = title;
        EnglishTitle = englishTitle;
        Description = description;
        HowToUse = howToUse;
        SupplementGroupId = supplementGroupId;
    }

    public static ErrorOr<Supplement> Create(CreateSupplementCommand command)
    {
        return new Supplement(
            Guid.NewGuid(),
            command.Title,
            command.EnglishTitle,
            command.Description,
            command.HowToUse,
            command.SupplementGroupId
        );
    }

    public static ErrorOr<Supplement> Update(Supplement existing, UpdateSupplementCommand command)
    {
        return new Supplement(
            existing.Id,
            command.Title,
            command.EnglishTitle,
            command.Description,
            command.HowToUse,
            command.SupplementGroupId
        );
    }
}
