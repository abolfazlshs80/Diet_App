using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Role.Delete;
namespace Diet.Domain.UseCase.Role.Commands.Create
{
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator()
        {
            // Add validation rules here
        }
    }
}
