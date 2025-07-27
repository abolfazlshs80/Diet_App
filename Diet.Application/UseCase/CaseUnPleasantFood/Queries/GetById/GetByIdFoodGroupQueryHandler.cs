using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.CaseUnPleasantFood.GetById;
using Diet.Domain.user.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;

using Diet.Domain.CaseUnPleasantFood.Repository;

namespace Diet.Application.UseCase.CaseUnPleasantFood.Queries.GetById;

public class GetByIdCaseUnPleasantFoodQueryHandler : IQueryHandler<GetByIdCaseUnPleasantFoodQuery, GetByIdCaseUnPleasantFoodQueryResult>
{
    private readonly ICaseUnPleasantFoodRepository _CaseUnPleasantFoodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdCaseUnPleasantFoodQueryHandler(ICaseUnPleasantFoodRepository CaseUnPleasantFoodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseUnPleasantFoodRepository = CaseUnPleasantFoodRepository;
    }


    public async Task<ErrorOr<GetByIdCaseUnPleasantFoodQueryResult>> Handle(GetByIdCaseUnPleasantFoodQuery Query)
    {
        var result = await _CaseUnPleasantFoodRepository.ByIdAsync(Query.Id);
        if (result == null)
            return Error.NotFound("NotFound");


        return new GetByIdCaseUnPleasantFoodQueryResult(result.Id,result.CaseId,result.FoodId);
    }
}
