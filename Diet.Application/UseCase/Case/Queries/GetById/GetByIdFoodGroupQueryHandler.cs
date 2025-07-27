using Diet.Application.Interface;
using Diet.Domain.@case.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.Case.GetById;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Reflection;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.Case.Queries.GetById;

public class GetByIdCaseQueryHandler : IQueryHandler<GetByIdCaseQuery, GetByIdCaseQueryResult>
{
    private readonly ICaseRepository _CaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdCaseQueryHandler(ICaseRepository CaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseRepository = CaseRepository;
    }


    public async Task<ErrorOr<GetByIdCaseQueryResult>> Handle(GetByIdCaseQuery Query)
    {
        var result = await _CaseRepository.ByIdAsync(Query.Id);
        if (result == null)
            return Error.NotFound("Case");


        return new GetByIdCaseQueryResult(
    result.Weight,
    result.Height,
    result.BirthDate,
    result.Description,
    result.Gender,
    result.BodyActivity,
    result.IsSport,
    result.SportActivity,
    result.ChangeWeightType,
    result.WeightChangeAmount,
    result.ExerciseTime,
    result.Id,
    result.SportId,

    result.ExerciseDay,
    result.DateOfStart,
    result.BodyForm,
    result.LifeCourseId,

    result.UserId,

    result.TransactionId);
    }
}
