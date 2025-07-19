using Diet.Domain.common;

namespace Diet.Domain.supplement.Entities;
/// <summary>
///   برای دسته‌بندی مکمل‌های غذایی است.
/// </summary>
public sealed class SupplementGroup: BaseEntity
{
    private SupplementGroup() { }
    public string Title { get; private set; }
    public  ICollection<Supplement> Supplement { get; private set; }
}
