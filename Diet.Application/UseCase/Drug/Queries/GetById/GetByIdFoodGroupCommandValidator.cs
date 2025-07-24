using Diet.Domain.Contract.Queries.Drug.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.Drug.Queries.GetById;

public class GetByIdDrugQueryValidator : AbstractValidator<GetByIdDrugQuery>
{
    public GetByIdDrugQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

