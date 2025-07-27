using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.CasePleasantFood.GetById;
using Diet.Domain.user.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;

using Diet.Domain.CasePleasantFood.Repository;

namespace Diet.Application.UseCase.CasePleasantFood.Queries.GetById;

public class GetByIdCasePleasantFoodQueryHandler : IQueryHandler<GetByIdCasePleasantFoodQuery, GetByIdCasePleasantFoodQueryResult>
{
    private readonly ICasePleasantFoodRepository _CasePleasantFoodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdCasePleasantFoodQueryHandler(ICasePleasantFoodRepository CasePleasantFoodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CasePleasantFoodRepository = CasePleasantFoodRepository;
    }


    public async Task<ErrorOr<GetByIdCasePleasantFoodQueryResult>> Handle(GetByIdCasePleasantFoodQuery Query)
    {
        var result = await _CasePleasantFoodRepository.ByIdAsync(Query.Id);
        if (result == null)
            return Error.NotFound("NotFound");


        return new GetByIdCasePleasantFoodQueryResult(result.Id,result.CaseId,result.FoodId);
    }
}
