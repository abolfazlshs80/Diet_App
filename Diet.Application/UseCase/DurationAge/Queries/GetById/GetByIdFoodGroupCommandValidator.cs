using Diet.Domain.Contract.Queries.DurationAge.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.DurationAge.Queries.GetById;

public class GetByIdDurationAgeQueryValidator : AbstractValidator<GetByIdDurationAgeQuery>
{
    public GetByIdDurationAgeQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

