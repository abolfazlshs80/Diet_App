using Diet.Domain.Contract.Queries.CasePleasantFood.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.CasePleasantFood.Queries.GetById;

public class GetByIdCasePleasantFoodQueryValidator : AbstractValidator<GetByIdCasePleasantFoodQuery>
{
    public GetByIdCasePleasantFoodQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
 

    }
}

