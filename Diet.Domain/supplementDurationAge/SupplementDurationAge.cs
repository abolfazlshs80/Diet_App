using Diet.Domain.common;
using Diet.Domain.durationAge.Entities;
using ErrorOr;
using Diet.Domain.Contract.Commands.SupplementDurationAge.Update;
using Diet.Domain.Contract.Commands.SupplementDurationAge.Create;
using Diet.Domain.supplement;

namespace Diet.Domain.supplementDurationAge;

/// <summary>
///   نگهدارنده مکمل‌های مجاز برای بیماری‌های خاص است.
/// </summary>
public sealed class SupplementDurationAge: BaseEntity
{
    private SupplementDurationAge() { }

    public Guid SupplementId { get; private set; }

    public Supplement Supplement { get; private set; }

    public Guid DurationAgeId { get; private set; }

    public DurationAge DurationAge { get; private set; }

    private SupplementDurationAge(Guid id, Guid supplementId, Guid durationAgeId)
    {
        Id = id;
        SupplementId = supplementId;
        DurationAgeId = durationAgeId;
    }

    public static ErrorOr<SupplementDurationAge> Create(CreateSupplementDurationAgeCommand command)
    {
        return new SupplementDurationAge(
            Guid.NewGuid(),
            command.SupplementId,
            command.DurationAgeId
        );
    }

    public static ErrorOr<SupplementDurationAge> Update(SupplementDurationAge existing, UpdateSupplementDurationAgeCommand command)
    {
        return new SupplementDurationAge(
            existing.Id,
            command.SupplementId,
            command.DurationAgeId
        );
    }
}