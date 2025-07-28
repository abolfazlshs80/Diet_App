using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Users.Create;
namespace Diet.Domain.UseCase.Users.Commands.Create
{
    public class CreateUsersCommandValidator : AbstractValidator<CreateUsersCommand>
    {
        public CreateUsersCommandValidator()
        {
            // Add validation rules here
        }
    }
}
