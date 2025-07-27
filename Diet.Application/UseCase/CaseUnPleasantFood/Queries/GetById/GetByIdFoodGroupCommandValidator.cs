using Diet.Domain.Contract.Queries.CaseUnPleasantFood.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.CaseUnPleasantFood.Queries.GetById;

public class GetByIdCaseUnPleasantFoodQueryValidator : AbstractValidator<GetByIdCaseUnPleasantFoodQuery>
{
    public GetByIdCaseUnPleasantFoodQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
 

    }
}

