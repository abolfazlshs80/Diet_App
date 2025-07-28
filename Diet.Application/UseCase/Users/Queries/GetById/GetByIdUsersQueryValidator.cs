using FluentValidation;
using Diet.Domain.Contract.Queries.Users.GetById;
namespace Diet.Application.UseCase.Users.Queries.GetById;

public class GetByIdUsersQueryValidator : AbstractValidator<GetByIdUsersQuery>
{
    public GetByIdUsersQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
