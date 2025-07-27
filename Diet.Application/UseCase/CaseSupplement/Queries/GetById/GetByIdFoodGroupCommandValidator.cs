using Diet.Domain.Contract.Queries.CaseSupplement.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.CaseSupplement.Queries.GetById;

public class GetByIdCaseSupplementQueryValidator : AbstractValidator<GetByIdCaseSupplementQuery>
{
    public GetByIdCaseSupplementQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
 

    }
}

