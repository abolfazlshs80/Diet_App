using FluentValidation;
using Diet.Domain.Contract.Queries.SupplementGroup.GetById;
namespace Diet.Application.UseCase.SupplementGroup.Queries.GetById;

public class GetByIdSupplementGroupQueryValidator : AbstractValidator<GetByIdSupplementGroupQuery>
{
    public GetByIdSupplementGroupQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
