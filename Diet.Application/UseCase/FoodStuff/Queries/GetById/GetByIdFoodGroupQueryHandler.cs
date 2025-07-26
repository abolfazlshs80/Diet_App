using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.FoodStuff.GetById;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Application.Interface;
using static FoodStuff.Domain.FoodStuff.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodStuff.Queries.GetById;

public class GetByIdFoodStuffQueryHandler : IQueryHandler<GetByIdFoodStuffQuery, GetByIdFoodStuffQueryResult>
{
    private readonly IFoodStuffRepository _FoodStuffRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdFoodStuffQueryHandler(IFoodStuffRepository FoodStuffRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodStuffRepository = FoodStuffRepository;
    }


    public async Task<ErrorOr<GetByIdFoodStuffQueryResult>> Handle(GetByIdFoodStuffQuery Query)
    {
        var result = await _FoodStuffRepository.ByIdAsync(Query.Id);
        if (result == null)
            return FoodStuff_Error.FoodStuff_NotFount;


        return new GetByIdFoodStuffQueryResult(result.Id,result.Title);
    }
}
