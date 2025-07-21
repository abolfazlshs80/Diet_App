using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.FoodGroup.GetById;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodGroup.Domain.FoodGroup.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodGroup.Queries.GetById;

public class GetByIdFoodGroupQueryHandler : IQueryHandler<GetByIdFoodGroupQuery, GetByIdFoodGroupQueryResult>
{
    private readonly IFoodGroupRepository _foodGroupRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public GetByIdFoodGroupQueryHandler(IFoodGroupRepository foodGroupRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _foodGroupRepository = foodGroupRepository;
    }


    public async Task<ErrorOr<GetByIdFoodGroupQueryResult>> Handle(GetByIdFoodGroupQuery Query)
    {
        var result = await _foodGroupRepository.ById(Query.Id);
        if (result == null)
            return FoodGroup_Error.FoodGroup_NotFount;


        return new GetByIdFoodGroupQueryResult(result.Id,result.Title);
    }
}
