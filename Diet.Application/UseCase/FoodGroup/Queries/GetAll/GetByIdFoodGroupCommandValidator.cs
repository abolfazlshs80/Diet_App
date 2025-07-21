
using Diet.Domain.Contract.Queries.FoodGroup.GetAll;
using FluentValidation;

namespace Diet.Application.UseCase.FoodGroup.Queries.GetAll;

public class GetAllFoodGroupQueryValidator : AbstractValidator<GetAllFoodGroupQuery>
{
    public GetAllFoodGroupQueryValidator()
    {
     

    }
}

