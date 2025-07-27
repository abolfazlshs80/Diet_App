using Diet.Domain.Contract.Queries.CaseFoodStuffAllergy.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.CaseFoodStuffAllergy.Queries.GetById;

public class GetByIdCaseFoodStuffAllergyQueryValidator : AbstractValidator<GetByIdCaseFoodStuffAllergyQuery>
{
    public GetByIdCaseFoodStuffAllergyQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
 

    }
}

