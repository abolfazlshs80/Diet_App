using Diet.Application.Interface;
using Diet.Domain.@case.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.Case.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Reflection;
namespace Diet.Application.UseCase.Case.Queries.GetAll;

public class GetAllCaseQueryHandler : IQueryHandler<GetAllCaseQuery,GetAllCaseQueryResult>
{
    private readonly ICaseRepository _CaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCaseQueryHandler(ICaseRepository CaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseRepository = CaseRepository;
    }


    public async Task<ErrorOr<GetAllCaseQueryResult>> Handle(GetAllCaseQuery Query)
    {
        var result = await _CaseRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllCaseQueryResult(result.Count, result.Select(_ => new GetCaseItem(_.Id,
            _.Weight,
            _.Height,
            _.BirthDate,
            _.Description,
            _.Gender,
            _.BodyActivity,
            _.IsSport,
            _.SportActivity,
            _.ChangeWeightType,
            _.WeightChangeAmount,
            _.ExerciseTime,
            _.SportId,

            _.ExerciseDay,
            _.DateOfStart,
            _.BodyForm,
            _.LifeCourseId,

            _.UserId,

            _.TransactionId)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
