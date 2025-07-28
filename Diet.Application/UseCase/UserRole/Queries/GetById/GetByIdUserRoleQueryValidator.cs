using FluentValidation;
using Diet.Domain.Contract.Queries.UserRole.GetById;
namespace Diet.Application.UseCase.UserRole.Queries.GetById;

public class GetByIdUserRoleQueryValidator : AbstractValidator<GetByIdUserRoleQuery>
{
    public GetByIdUserRoleQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
