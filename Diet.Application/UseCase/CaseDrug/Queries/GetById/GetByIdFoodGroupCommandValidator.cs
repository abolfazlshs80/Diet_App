using Diet.Domain.Contract.Queries.CaseDrug.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.CaseDrug.Queries.GetById;

public class GetByIdCaseDrugQueryValidator : AbstractValidator<GetByIdCaseDrugQuery>
{
    public GetByIdCaseDrugQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
 

    }
}

