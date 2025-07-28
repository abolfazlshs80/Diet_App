using FluentValidation;
using Diet.Domain.Contract.Queries.SupplementDurationAge.GetById;
namespace Diet.Application.UseCase.SupplementDurationAge.Queries.GetById;

public class GetByIdSupplementDurationAgeQueryValidator : AbstractValidator<GetByIdSupplementDurationAgeQuery>
{
    public GetByIdSupplementDurationAgeQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
