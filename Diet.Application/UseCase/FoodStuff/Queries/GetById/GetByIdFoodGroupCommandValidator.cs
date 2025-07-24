using Diet.Domain.Contract.Queries.FoodStuff.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.FoodStuff.Queries.GetById;

public class GetByIdFoodStuffQueryValidator : AbstractValidator<GetByIdFoodStuffQuery>
{
    public GetByIdFoodStuffQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

