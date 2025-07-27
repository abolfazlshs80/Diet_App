using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Role.Update;
namespace Diet.Domain.UseCase.Role.Commands.Create
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            // Add validation rules here
        }
    }
}
