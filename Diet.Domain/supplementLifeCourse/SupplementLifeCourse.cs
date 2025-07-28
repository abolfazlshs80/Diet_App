using Diet.Domain.common;
using Diet.Domain.lifeCourse.Entities;
using ErrorOr;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Update;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Create;
using Diet.Domain.supplement;

namespace Diet.Domain.supplementLifeCourse;
/// <summary>
///   برای نگهداری اطلاعات مکمل‌های مناسب هر دوره زندگی است.
/// </summary>
public sealed class SupplementLifeCourse : BaseEntity
{
    private SupplementLifeCourse() { }

    public Guid SupplementId { get; private set; }

    public  Supplement Supplement { get; private set; }

    public Guid LifeCourseId { get; private set; }

    public  LifeCourse LifeCourse { get; private set; }


    private SupplementLifeCourse(Guid id, Guid supplementId, Guid lifeCourseId)
    {
        Id = id;
        SupplementId = supplementId;
        LifeCourseId = lifeCourseId;
    }

    public static ErrorOr<SupplementLifeCourse> Create(CreateSupplementLifeCourseCommand command)
    {
        return new SupplementLifeCourse(
            Guid.NewGuid(),
            command.SupplementId,
            command.LifeCourseId
        );
    }

    public static ErrorOr<SupplementLifeCourse> Update(SupplementLifeCourse existing, UpdateSupplementLifeCourseCommand command)
    {
        return new SupplementLifeCourse(
            existing.Id,
            command.SupplementId,
            command.LifeCourseId
        );
    }
}