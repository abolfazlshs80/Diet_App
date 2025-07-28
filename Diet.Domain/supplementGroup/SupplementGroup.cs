using Diet.Domain.common;
using ErrorOr;
using Diet.Domain.Contract.Commands.SupplementGroup.Update;
using Diet.Domain.Contract.Commands.SupplementGroup.Create;
using Diet.Domain.supplement;

namespace Diet.Domain.supplementGroup;
/// <summary>
///   برای دسته‌بندی مکمل‌های غذایی است.
/// </summary>
public sealed class SupplementGroup: BaseEntity
{
    private SupplementGroup() { }
    public string Title { get; private set; }
    public  ICollection<Supplement> Supplement { get; private set; }


    private SupplementGroup(Guid id, string title)
    {
        Id = id;
        Title = title;
    }

    public static ErrorOr<SupplementGroup> Create(CreateSupplementGroupCommand command)
    {
        return new SupplementGroup(
            Guid.NewGuid(),
            command.Title
        );
    }

    public static ErrorOr<SupplementGroup> Update(SupplementGroup existing, UpdateSupplementGroupCommand command)
    {
        return new SupplementGroup(
            existing.Id,
            command.Title
        );
    }
}
