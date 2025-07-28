using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.UserRole.Delete;
namespace Diet.Domain.UseCase.UserRole.Commands.Create
{
    public class DeleteUserRoleCommandValidator : AbstractValidator<DeleteUserRoleCommand>
    {
        public DeleteUserRoleCommandValidator()
        {
            // Add validation rules here
        }
    }
}
