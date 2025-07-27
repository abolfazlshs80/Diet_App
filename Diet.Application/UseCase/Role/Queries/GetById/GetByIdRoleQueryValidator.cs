using FluentValidation;
using Diet.Domain.Contract.Queries.Role.GetById;
namespace Diet.Application.UseCase.Role.Queries.GetById;

public class GetByIdRoleQueryValidator : AbstractValidator<GetByIdRoleQuery>
{
    public GetByIdRoleQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
