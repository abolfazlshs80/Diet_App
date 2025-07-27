using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Role.Create;
namespace Diet.Domain.UseCase.Role.Commands.Create
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            // Add validation rules here
        }
    }
}
