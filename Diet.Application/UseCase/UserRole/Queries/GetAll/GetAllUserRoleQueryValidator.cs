using FluentValidation;
using Diet.Domain.Contract.Queries.UserRole.GetAll;
namespace Diet.Application.UseCase.UserRole.Queries.GetAll;

public class GetAllUserRoleQueryValidator : AbstractValidator<GetAllUserRoleQuery>
{
    public GetAllUserRoleQueryValidator()
    {
        
    }
}
