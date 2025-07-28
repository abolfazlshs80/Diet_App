using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.UserRole.Create;
namespace Diet.Domain.UseCase.UserRole.Commands.Create
{
    public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleCommandValidator()
        {
            // Add validation rules here
        }
    }
}
