using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.FoodGroup.GetById;
using Diet.Domain.user.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodGroup.Domain.FoodGroup.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodGroup.Queries.GetById;

public class GetByIdFoodGroupQueryHandler : IQueryHandler<GetByIdFoodGroupQuery, GetByIdFoodGroupQueryResult>
{
    private readonly IFoodGroupRepository _foodGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdFoodGroupQueryHandler(IFoodGroupRepository foodGroupRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _foodGroupRepository = foodGroupRepository;
    }


    public async Task<ErrorOr<GetByIdFoodGroupQueryResult>> Handle(GetByIdFoodGroupQuery Query)
    {
        var result = await _foodGroupRepository.ByIdAsync(Query.Id);
        if (result == null)
            return FoodGroup_Error.FoodGroup_NotFount;


        return new GetByIdFoodGroupQueryResult(result.Id,result.Title);
    }
}
