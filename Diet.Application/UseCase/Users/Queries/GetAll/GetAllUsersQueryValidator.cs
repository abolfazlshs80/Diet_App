using FluentValidation;
using Diet.Domain.Contract.Queries.Users.GetAll;
namespace Diet.Application.UseCase.Users.Queries.GetAll;

public class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
{
    public GetAllUsersQueryValidator()
    {
        
    }
}
