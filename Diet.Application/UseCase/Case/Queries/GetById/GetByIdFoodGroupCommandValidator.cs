using Diet.Domain.Contract.Queries.Case.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.Case.Queries.GetById;

public class GetByIdCaseQueryValidator : AbstractValidator<GetByIdCaseQuery>
{
    public GetByIdCaseQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

