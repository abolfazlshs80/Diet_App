using Diet.Domain.Contract.Queries.Food.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.Food.Queries.GetById;

public class GetByIdFoodQueryValidator : AbstractValidator<GetByIdFoodQuery>
{
    public GetByIdFoodQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

