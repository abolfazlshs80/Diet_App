using FluentValidation;
using Diet.Domain.Contract.Queries.Sport.GetById;
namespace Diet.Application.UseCase.Sport.Queries.GetById;

public class GetByIdSportQueryValidator : AbstractValidator<GetByIdSportQuery>
{
    public GetByIdSportQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
