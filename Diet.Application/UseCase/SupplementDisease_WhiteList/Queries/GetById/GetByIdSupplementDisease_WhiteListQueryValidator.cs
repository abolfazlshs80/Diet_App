using FluentValidation;
using Diet.Domain.Contract.Queries.SupplementDisease_WhiteList.GetById;
namespace Diet.Application.UseCase.SupplementDisease_WhiteList.Queries.GetById;

public class GetByIdSupplementDisease_WhiteListQueryValidator : AbstractValidator<GetByIdSupplementDisease_WhiteListQuery>
{
    public GetByIdSupplementDisease_WhiteListQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
