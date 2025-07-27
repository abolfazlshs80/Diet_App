using FluentValidation;
using Diet.Domain.Contract.Queries.Role.GetAll;
namespace Diet.Application.UseCase.Role.Queries.GetAll;

public class GetAllRoleQueryValidator : AbstractValidator<GetAllRoleQuery>
{
    public GetAllRoleQueryValidator()
    {
        
    }
}
