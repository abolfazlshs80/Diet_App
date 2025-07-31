using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.disease;

using Diet.Domain.food.Entities;
using ErrorOr;

namespace Diet.Domain.caseDisease;

public sealed class CaseDisease : BaseEntity
{
    private CaseDisease() { }
    private CaseDisease(Guid id, Guid caseId, Guid diseaseId) { Id = id; CaseId = caseId; DiseaseId = diseaseId; }
    public Guid CaseId { get; private set; }
    public Diet.Domain.Case.Case Case { get; private set; }

    public Guid DiseaseId { get; private set; }
    public disease.Disease Disease { get; private set; }

    public static ErrorOr<CaseDisease> Create(CreateCaseDiseaseCommand command)
    {

        return new CaseDisease(Guid.NewGuid(), command.CaseId, command.DiseaseId);


    }

    public static ErrorOr<CaseDisease> Update(CaseDisease CaseDisease, UpdateCaseDiseaseCommand command)
    {
        return new CaseDisease(CaseDisease.Id, command.CaseId, command.DiseaseId);


    }
}
