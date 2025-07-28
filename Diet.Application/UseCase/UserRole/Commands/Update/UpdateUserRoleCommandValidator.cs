using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.UserRole.Update;
namespace Diet.Domain.UseCase.UserRole.Commands.Create
{
    public class UpdateUserRoleCommandValidator : AbstractValidator<UpdateUserRoleCommand>
    {
        public UpdateUserRoleCommandValidator()
        {
            // Add validation rules here
        }
    }
}
