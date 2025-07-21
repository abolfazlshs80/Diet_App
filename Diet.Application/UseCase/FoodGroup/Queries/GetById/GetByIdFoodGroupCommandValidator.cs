using Diet.Domain.Contract.Queries.FoodGroup.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.FoodGroup.Queries.GetById;

public class GetByIdFoodGroupQueryValidator : AbstractValidator<GetByIdFoodGroupQuery>
{
    public GetByIdFoodGroupQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

