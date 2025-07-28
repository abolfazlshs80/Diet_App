using FluentValidation;
using Diet.Domain.Contract.Queries.Supplement.GetById;
namespace Diet.Application.UseCase.Supplement.Queries.GetById;

public class GetByIdSupplementQueryValidator : AbstractValidator<GetByIdSupplementQuery>
{
    public GetByIdSupplementQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
