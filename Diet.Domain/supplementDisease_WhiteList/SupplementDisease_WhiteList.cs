using Diet.Domain.common;
using Diet.Domain.disease;
using ErrorOr;
using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Update;
using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Create;
using Diet.Domain.supplement;

namespace Diet.Domain.supplementDisease_WhiteList;
/// <summary>
///   نگهدارنده مکمل‌های مجاز برای بیماری‌های خاص است.
/// </summary>
public sealed class SupplementDisease_WhiteList:BaseEntity
{
    private SupplementDisease_WhiteList() { }

    public Guid SupplementId { get; private set; }

    public  Supplement Supplement { get; private set; }

    public Guid DiseaseId { get; private set; }
    
    public disease.Disease Disease { get; private set; }

    private SupplementDisease_WhiteList(Guid id, Guid supplementId, Guid diseaseId)
    {
        Id = id;
        SupplementId = supplementId;
        DiseaseId = diseaseId;
    }

    public static ErrorOr<SupplementDisease_WhiteList> Create(CreateSupplementDisease_WhiteListCommand command)
    {
        return new SupplementDisease_WhiteList(
            Guid.NewGuid(),
            command.SupplementId,
            command.DiseaseId
        );
    }

    public static ErrorOr<SupplementDisease_WhiteList> Update(SupplementDisease_WhiteList existing, UpdateSupplementDisease_WhiteListCommand command)
    {
        return new SupplementDisease_WhiteList(
            existing.Id,
            command.SupplementId,
            command.DiseaseId
        );
    }
}
